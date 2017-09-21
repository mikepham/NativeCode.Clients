using NativeCode.BitBucket.JsonExtensions;
using Newtonsoft.Json;

namespace NativeCode.BitBucket.Extensions
{
    internal static class SerializationOptions
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new UnderscoreContractResolver(),
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
        };
    }
}