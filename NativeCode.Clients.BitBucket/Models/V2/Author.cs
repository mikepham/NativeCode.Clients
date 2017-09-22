namespace NativeCode.Clients.BitBucket.Models.V2
{
    using System.Runtime.Serialization;
    using JsonExtensions;
    using Newtonsoft.Json;

    [DataContract]
    public class Author
    {
        [DataMember]
        public string Raw { get; protected set; }

        [DataMember]
        [JsonConverter(typeof(EnumJsonConverter))]
        public ResourceType Type { get; protected set; }

        [DataMember]
        public User User { get; protected set; }
    }
}