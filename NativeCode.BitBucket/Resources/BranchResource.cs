using System;
using NativeCode.BitBucket.Models.V2;

namespace NativeCode.BitBucket.Resources
{
    public class BranchResource : BitBucketResource<Branch>
    {
        public BranchResource(IBitBucketClient client) : base(client)
        {
        }

        public override string GetResourcePageUrl(BitBucketClientContext context)
        {
            switch (context.ClientType)
            {
                case BitBucketClientType.ApiV1:
                    throw new NotSupportedException();

                case BitBucketClientType.ApiV2:
                case BitBucketClientType.None:
                    return $"/2.0/repositories/{context.IdSlug}/{context.RepoSlug}/refs/branches";

                default:
                    throw new InvalidOperationException();
            }
        }

        public override string GetActionUrl(BitBucketClientContext context)
        {
            switch (context.ClientType)
            {
                case BitBucketClientType.ApiV1:
                    throw new NotSupportedException();

                case BitBucketClientType.ApiV2:
                case BitBucketClientType.None:
                    return $"/2.0/repositories/{context.IdSlug}/{context.RepoSlug}/refs/branches/{context.BranchSlug}";

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
                case BitBucketClientType.None:
                    return $"/2.0/repositories/{context.IdSlug}/{context.RepoSlug}/refs/branches/{context.BranchSlug}";

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}