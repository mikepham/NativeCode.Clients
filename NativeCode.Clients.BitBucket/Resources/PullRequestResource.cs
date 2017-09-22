namespace NativeCode.Clients.BitBucket.Resources
{
    using System;
    using V2;

    public class PullRequestResource : RestResource<PullRequest, BitBucketClientContext>
    {
        public PullRequestResource(IBitBucketClient client) : base(client)
        {
        }

        public override string GetActionUrl(BitBucketClientContext context)
        {
            switch (context.ClientType)
            {
                case BitBucketClientType.ApiV1:
                    throw new NotSupportedException();

                case BitBucketClientType.ApiV2:
                case BitBucketClientType.Cloud:
                    return
                        $"/2.0/repositories/{context.IdSlug}/{context.RepoSlug}/pullrequests/{context.PullRequestSlug}";

                default:
                    throw new InvalidOperationException();
            }
        }

        public override string GetResourceUrl(BitBucketClientContext context)
        {
            switch (context.ClientType)
            {
                case BitBucketClientType.ApiV1:
                    throw new NotSupportedException();

                case BitBucketClientType.ApiV2:
                case BitBucketClientType.Cloud:
                    return $"/2.0/repositories/{context.IdSlug}/{context.RepoSlug}/pullrequests";

                default:
                    throw new InvalidOperationException();
            }
        }

        public override string GetPagingUrl(BitBucketClientContext context)
        {
            switch (context.ClientType)
            {
                case BitBucketClientType.ApiV1:
                    throw new NotSupportedException();

                case BitBucketClientType.ApiV2:
                case BitBucketClientType.Cloud:
                    return
                        $"/2.0/repositories/{context.IdSlug}/{context.RepoSlug}/pullrequests/{context.PullRequestSlug}";

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}