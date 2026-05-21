using System.Collections.Generic;

namespace Story.Persistence
{
    public class ImageRepository
    {
        // Cheia = calea relativă din JSON (ex: "images/forest.jpg")
        private readonly Dictionary<string, System.Drawing.Image> _images
            = new Dictionary<string, System.Drawing.Image>();

        public void Add(string relativePath, System.Drawing.Image image)
        {
            _images[relativePath] = image;
        }

        public bool Contains(string relativePath)
        {
            return !string.IsNullOrEmpty(relativePath) && _images.ContainsKey(relativePath);
        }

        public System.Drawing.Image Get(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
                return null;

            return _images.TryGetValue(relativePath, out var img) ? img : null;
        }

        public IEnumerable<string> AllPaths => _images.Keys;

        public void Clear()
        {
            foreach (var img in _images.Values)
                img?.Dispose();
            _images.Clear();
        }
    }
}