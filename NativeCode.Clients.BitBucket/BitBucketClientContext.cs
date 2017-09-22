namespace NativeCode.Clients.BitBucket
{
    using Models.V2;

    public class BitBucketClientContext : ClientContext
    {
        public string BranchSlug { get; set; }

        public BitBucketClientType ClientType { get; set; }

        public string IdSlug { get; set; }

        public string PullRequestSlug { get; set; }

        public string RepoSlug { get; set; }

        public ResourceType ResourceType { get; set; }
    }
}