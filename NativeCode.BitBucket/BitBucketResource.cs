using System;
using Humanizer;

namespace NativeCode.BitBucket
{
    public abstract class BitBucketResource<T> : IBitBucketResource<T>
        where T : class, new()
    {
        protected BitBucketResource(IBitBucketClient client)
        {
            this.Client = client;
        }

        protected IBitBucketClient Client { get; }

        public virtual string ResourceName => typeof(T).Name.Camelize();

        public virtual Type Type => typeof(T);

        public abstract string GetUrl(BitBucketClientContext context);
    }
}