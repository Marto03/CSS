using System;
using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace WpfApp1.Models
{
    public class Convert<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader,
         Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<T>(reader);
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
