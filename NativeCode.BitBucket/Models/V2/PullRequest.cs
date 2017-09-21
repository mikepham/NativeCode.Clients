using System;
using System.Runtime.Serialization;
using NativeCode.BitBucket.JsonExtensions;
using Newtonsoft.Json;

namespace NativeCode.BitBucket.Models.V2
{
    [DataContract]
    public class PullRequest : ResourceResponse<PullRequest>
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
        public PullRequestState State { get; }

        [DataMember]
        public int TaskCount { get; }

        [DataMember]
        public string Title { get; }

        [DataMember]
        [JsonConverter(typeof(EnumValueConverter))]
        public BitBucketResourceType Type { get; }

        [DataMember]
        public DateTimeOffset UpdatedOn { get; }
    }
}