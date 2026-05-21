using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Story.Model;

namespace Story.Persistence
{
    public static class StoryJsonSerializer
    {
        private static readonly JsonSerializerSettings Settings = CreateSettings();

        private static JsonSerializerSettings CreateSettings()
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            // Enum-urile (EffectType, ConditionType) ca string, nu ca număr
            settings.Converters.Add(new StringEnumConverter());

            // Converterul nostru polimorfic pentru ConditionNode
            settings.Converters.Add(new ConditionJsonConverter());

            return settings;
        }

        public static string Serialize(StoryDefinition story)
        {
            return JsonConvert.SerializeObject(story, Settings);
        }

        public static StoryDefinition Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<StoryDefinition>(json, Settings);
        }
    }
}