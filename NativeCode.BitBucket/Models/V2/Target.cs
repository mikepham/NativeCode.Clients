using System;
using System.Runtime.Serialization;
using NativeCode.BitBucket.JsonExtensions;
using Newtonsoft.Json;

namespace NativeCode.BitBucket.Models.V2
{
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