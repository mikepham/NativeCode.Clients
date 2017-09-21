using System;
using Newtonsoft.Json;

namespace NativeCode.BitBucket.JsonExtensions
{
    public class EnumValueConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                writer.WriteValue(Enum.GetName(value.GetType(), value));
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType.IsEnum && existingValue is string)
            {
                return Enum.Parse(objectType, (string) existingValue, true);
            }

            return existingValue;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }
    }
}