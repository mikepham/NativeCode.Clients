using System.Runtime.Serialization;
using NativeCode.BitBucket.JsonExtensions;
using Newtonsoft.Json;

namespace NativeCode.BitBucket.Models.V2
{
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