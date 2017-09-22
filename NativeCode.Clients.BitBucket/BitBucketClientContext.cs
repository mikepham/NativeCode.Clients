namespace NativeCode.BitBucket
{
    using System.Collections.Generic;
    using Models.V2;

    public class BitBucketClientContext
    {
        public string BranchSlug { get; set; }

        public BitBucketClientType ClientType { get; set; }

        public string IdSlug { get; set; }

        public IDictionary<string, string> Parameters { get; } = new Dictionary<string, string>();

        public string PullRequestSlug { get; set; }

        public string RepoSlug { get; set; }

        public ResourceType ResourceType { get; set; }
    }
}