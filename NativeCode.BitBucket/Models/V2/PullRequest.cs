using System;

namespace NativeCode.BitBucket.Models.V2
{
    public class PullRequest : ResourceResponse<PullRequest>
    {
        public string ClosedBy { get; }

        public bool CloseSourceBranch { get; }

        public short CommentCount { get; }

        public DateTimeOffset CreatedOn { get; }

        public string Description { get; }

        public int Id { get; }

        public string MergeCommit { get; }

        public string Reason { get; }

        public PullRequestState State { get; }

        public int TaskCount { get; }

        public string Title { get; }

        public BitBucketResourceType Type { get; }

        public DateTimeOffset UpdatedOn { get; }
    }
}