namespace NativeCode.Clients.BitBucket.V2
{
    using System;
    using System.Runtime.Serialization;
    using JsonExtensions;
    using Newtonsoft.Json;

    [DataContract]
    public class Repository
    {
        [DataMember]
        public DateTimeOffset CreatedOn { get; protected set; }

        [DataMember]
        public string Description { get; protected set; }

        [DataMember]
        public string FullName { get; protected set; }

        [DataMember]
        public bool HasIssues { get; protected set; }

        [DataMember]
        public bool HasWiki { get; protected set; }

        [DataMember]
        public bool IsPrivate { get; protected set; }

        [DataMember]
        public string Language { get; protected set; }

        [DataMember]
        public string Name { get; protected set; }

        [DataMember]
        [JsonConverter(typeof(EnumJsonConverter))]
        public SourceControlType Scm { get; protected set; }

        [DataMember]
        public long Size { get; protected set; }

        [DataMember]
        public string Slug { get; protected set; }

        [DataMember]
        [JsonConverter(typeof(EnumJsonConverter))]
        public ResourceType Type { get; protected set; }

        [DataMember]
        public DateTimeOffset UpdatedOn { get; protected set; }

        [DataMember]
        public Guid Uuid { get; protected set; }
    }
}