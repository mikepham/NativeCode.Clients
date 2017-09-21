using System;
using System.Runtime.Serialization;
using NativeCode.BitBucket.JsonExtensions;
using Newtonsoft.Json;

namespace NativeCode.BitBucket.Models.V2
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string AccountId { get; protected set; }

        [DataMember]
        public DateTimeOffset CreatedOn { get; protected set; }

        [DataMember]
        public string DisplayName { get; protected set; }

        [DataMember]
        public bool IsStaff { get; protected set; }

        [DataMember]
        public string Location { get; protected set; }

        [DataMember]
        [JsonConverter(typeof(EnumValueConverter))]
        public ResourceType Type { get; protected set; }

        [DataMember]
        public string Username { get; protected set; }

        [DataMember]
        public Guid Uuid { get; protected set; }

        [DataMember]
        public string Website { get; protected set; }
    }
}