using System;
using JetBrains.Annotations;

namespace NativeCode.BitBucket
{
    public interface IBitBucketResource
    {
        [NotNull]
        string ResourceName { get; }

        [NotNull]
        Type Type { get; }

        [NotNull]
        string GetUrl([NotNull] BitBucketClientContext context);
    }

    public interface IBitBucketResource<T> : IBitBucketResource
        where T : class, new()
    {
    }
}