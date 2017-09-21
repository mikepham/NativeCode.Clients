using System;
using System.Runtime.Serialization;
using NativeCode.BitBucket.JsonExtensions;
using Newtonsoft.Json;

namespace NativeCode.BitBucket.Models.V2
{
    [DataContract]
    public class Repository
    {
        [DataMember]
        public string FullName { get; protected set; }

        [DataMember]
        public string Name { get; protected set; }

        [DataMember]
        [JsonConverter(typeof(EnumValueConverter))]
        public BitBucketResourceType Type { get; protected set; }

        [DataMember]
        public Guid Uuid { get; protected set; }
    }
}