namespace NativeCode.Clients.BitBucket.V2
{
    using System;
    using System.Runtime.Serialization;
    using JsonExtensions;
    using Newtonsoft.Json;

    [DataContract]
    public class Team
    {
        [DataMember]
        public DateTimeOffset CreatedOn { get; protected set; }

        [DataMember]
        public string DisplayName { get; protected set; }

        [DataMember]
        public string Location { get; protected set; }

        [DataMember]
        [JsonConverter(typeof(EnumJsonConverter))]
        public ResourceType Type { get; protected set; }

        [DataMember]
        public string Username { get; protected set; }

        [DataMember]
        public Guid Uuid { get; protected set; }

        [DataMember]
        public string Website { get; protected set; }
    }
}