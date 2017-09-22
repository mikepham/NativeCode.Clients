namespace NativeCode.Clients.BitBucket
{
    using V2;

    public class BitBucketClientContext : ClientContext
    {
        public string BranchSlug { get; set; }

        public BitBucketClientType ClientType { get; set; }

        public string IdSlug { get; set; }

        public string PullRequestSlug { get; set; }

        public string RepoSlug { get; set; }

        public RoleType Role
        {
            get => this.GetEnumParameter<RoleType>();
            set => this.SetEnumParameter(value);
        }

        public ResourceType ResourceType { get; set; }
    }
}