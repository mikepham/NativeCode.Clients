using System.Runtime.Serialization;
using NativeCode.BitBucket.JsonExtensions;
using Newtonsoft.Json;

namespace NativeCode.BitBucket.Models.V2
{
    [DataContract]
    public class Author
    {
        [DataMember]
        public string Raw { get; protected set; }
        
        [DataMember]
        [JsonConverter(typeof(EnumValueConverter))]
        public BitBucketResourceType Type { get; protected set; }
        
        [DataMember]
        public User User { get; protected set; }
    }
}