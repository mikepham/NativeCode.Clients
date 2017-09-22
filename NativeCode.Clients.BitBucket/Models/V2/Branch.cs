namespace NativeCode.Clients.BitBucket.Models.V2
{
    using System.Runtime.Serialization;
    using JsonExtensions;
    using Newtonsoft.Json;

    [DataContract]
    public class Branch
    {
        [DataMember]
        public string Name { get; protected set; }

        [DataMember]
        public Target Target { get; protected set; }

        [DataMember]
        [JsonConverter(typeof(EnumValueConverter))]
        public ResourceType Type { get; protected set; }
    }
}