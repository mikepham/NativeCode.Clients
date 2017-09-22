namespace NativeCode.Clients.BitBucket.Models.V2
{
    using System;
    using System.Runtime.Serialization;
    using JsonExtensions;
    using Newtonsoft.Json;

    [DataContract]
    public class PullRequest
    {
        [DataMember]
        public string ClosedBy { get; }

        [DataMember]
        public bool CloseSourceBranch { get; }

        [DataMember]
        public short CommentCount { get; }

        [DataMember]
        public DateTimeOffset CreatedOn { get; }

        [DataMember]
        public string Description { get; }

        [DataMember]
        public int Id { get; }

        [DataMember]
        public string MergeCommit { get; }

        [DataMember]
        public string Reason { get; }

        [DataMember]
        [JsonConverter(typeof(EnumJsonConverter))]
        public PullRequestState State { get; }

        [DataMember]
        public int TaskCount { get; }

        [DataMember]
        public string Title { get; }

        [DataMember]
        [JsonConverter(typeof(EnumJsonConverter))]
        public ResourceType Type { get; }

        [DataMember]
        public DateTimeOffset UpdatedOn { get; }
    }
}