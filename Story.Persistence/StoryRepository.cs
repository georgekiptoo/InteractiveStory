using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using Story.Model;

namespace Story.Persistence
{
    public class StoryRepository
    {
        private const string StoryJsonFileName = "story.json";
        private const string ImagesDirectory = "images/";

        // Încarcă povestea + imaginile din arhivă
        public LoadedStory Load(string zipPath)
        {
            if (!File.Exists(zipPath))
                throw new FileNotFoundException("Arhiva nu există.", zipPath);

            StoryDefinition story = null;
            var imageRepo = new ImageRepository();

            using (var archive = ZipFile.OpenRead(zipPath))
            {
                // 1. Citește story.json
                var jsonEntry = archive.GetEntry(StoryJsonFileName);
                if (jsonEntry == null)
                    throw new InvalidDataException(
                        $"Arhiva nu conține '{StoryJsonFileName}'.");

                using (var stream = jsonEntry.Open())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string json = reader.ReadToEnd();
                    story = StoryJsonSerializer.Deserialize(json);
                }

                // 2. Citește imaginile
                foreach (var entry in archive.Entries)
                {
                    if (!entry.FullName.StartsWith(ImagesDirectory,
                            StringComparison.OrdinalIgnoreCase))
                        continue;

                    if (string.IsNullOrEmpty(entry.Name)) // intrare director
                        continue;

                    using (var stream = entry.Open())
                    using (var memory = new MemoryStream())
                    {
                        stream.CopyTo(memory);
                        memory.Position = 0;

                        // Important: copiem în memorie ca imaginea să fie independentă de stream
                        var image = System.Drawing.Image.FromStream(memory);
                        imageRepo.Add(entry.FullName.Replace('\\', '/'), image);
                    }
                }
            }

            return new LoadedStory
            {
                Story = story,
                Images = imageRepo
            };
        }

        // Salvează povestea + imaginile într-o arhivă nouă
        // imagePaths: dicționar { calea relativă din JSON → calea fișierului local de pe disc }
        public void Save(string zipPath, StoryDefinition story,
            Dictionary<string, string> imagePaths)
        {
            // Dacă fișierul există, îl ștergem (ZipFile nu suprascrie)
            if (File.Exists(zipPath))
                File.Delete(zipPath);

            using (var archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                // 1. Scrie story.json
                var jsonEntry = archive.CreateEntry(StoryJsonFileName,
                    CompressionLevel.Optimal);
                using (var stream = jsonEntry.Open())
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    string json = StoryJsonSerializer.Serialize(story);
                    writer.Write(json);
                }

                // 2. Scrie imaginile
                if (imagePaths != null)
                {
                    foreach (var kvp in imagePaths)
                    {
                        string relativePath = kvp.Key;       // ex: "images/forest.jpg"
                        string sourcePath = kvp.Value;       // ex: "C:\imgs\forest.jpg"

                        if (!File.Exists(sourcePath))
                            continue; // sărim peste imagini lipsă; validarea ar trebui să le prindă

                        archive.CreateEntryFromFile(sourcePath, relativePath,
                            CompressionLevel.Optimal);
                    }
                }
            }
        }
    }

    // Rezultatul încărcării: povestea + imaginile asociate
    public class LoadedStory
    {
        public StoryDefinition Story { get; set; }
        public ImageRepository Images { get; set; }
    }
}