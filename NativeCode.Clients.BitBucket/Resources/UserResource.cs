namespace NativeCode.Clients.BitBucket.Resources
{
    using System;
    using V2;

    public class UserResource : RestResource<User, BitBucketClientContext>
    {
        public UserResource(IBitBucketClient client) : base(client)
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
                    return "/2.0/user";

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
                    return "/2.0/users";

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
                    return "/2.0/user";

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}