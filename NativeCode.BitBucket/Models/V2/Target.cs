namespace NativeCode.BitBucket.Models.V2
{
    using System;
    using System.Runtime.Serialization;
    using JsonExtensions;
    using Newtonsoft.Json;

    [DataContract]
    public class Target
    {
        [DataMember]
        public Author Author { get; protected set; }

        [DataMember]
        public DateTimeOffset Date { get; protected set; }

        [DataMember]
        public string Hash { get; protected set; }

        [DataMember]
        public string Message { get; protected set; }

        [DataMember]
        public Repository Repository { get; protected set; }

        [DataMember]
        [JsonConverter(typeof(EnumValueConverter))]
        public ResourceType Type { get; protected set; }
    }
}