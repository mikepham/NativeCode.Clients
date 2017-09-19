using System;
using NativeCode.BitBucket.Models.V2;

namespace NativeCode.BitBucket.Resources
{
    public class UserResource : BitBucketResource<User>
    {
        public UserResource(IBitBucketClient client) : base(client)
        {
        }

        public override string GetUrl(BitBucketClientContext context)
        {
            switch (context.ClientType)
            {
                case BitBucketClientType.ApiV1:
                    throw new NotSupportedException();

                case BitBucketClientType.ApiV2:
                    return $"/2.0/user";

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}