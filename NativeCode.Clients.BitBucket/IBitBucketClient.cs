namespace NativeCode.Clients.BitBucket
{
    using JetBrains.Annotations;
    using Resources;

    public interface IBitBucketClient : IRestClient<BitBucketClientContext>
    {
        [NotNull]
        BranchResource Branches { get; }

        BitBucketClientType ClientType { get; }

        [NotNull]
        PullRequestResource PullRequests { get; }

        [NotNull]
        TeamResource Teams { get; }

        [NotNull]
        UserResource Users { get; }

        [NotNull]
        BitBucketClientContext CreateContext([CanBeNull] string id = default(string), [CanBeNull] string repository = default(string));
    }
}