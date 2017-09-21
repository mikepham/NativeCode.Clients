using System;
using System.Net.Mime;
using NativeCode.BitBucket.Models.V2;

namespace NativeCode.BitBucket.Resources
{
    public class TeamResource : BitBucketResource<Team>
    {
        public TeamResource(IBitBucketClient client) : base(client)
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
                    return "/2.0/repositories/teams";

                default:
                    throw new InvalidOperationException();
            }
        }

        public override string GetResourcePageUrl(BitBucketClientContext context)
        {
            switch (context.ClientType)
            {
                case BitBucketClientType.ApiV1:
                    throw new NotSupportedException();

                case BitBucketClientType.ApiV2:
                case BitBucketClientType.Cloud:
                    return "/2.0/repositories/teams";

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
                    return "/2.0/repositories/teams";

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}