using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Story.Model;

namespace Story.Persistence
{
    public class ConditionJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ConditionNode).IsAssignableFrom(objectType);
        }

        // Citire: alege clasa concretă în funcție de câmpul "type"
        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject obj = JObject.Load(reader);
            string type = obj["type"]?.ToString();

            ConditionNode node;
            switch (type)
            {
                case "COMPARISON":
                    node = new ComparisonCondition();
                    break;
                case "AND":
                    node = new AndCondition();
                    break;
                case "OR":
                    node = new OrCondition();
                    break;
                default:
                    throw new JsonSerializationException(
                        $"Tip de condiție necunoscut: '{type}'");
            }

            serializer.Populate(obj.CreateReader(), node);
            return node;
        }

        // Scriere: serializare standard (câmpul "type" vine din enum-ul ConditionType)
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject obj = JObject.FromObject(value, serializer);
            obj.WriteTo(writer);
        }

        public override bool CanWrite => true;
    }
}