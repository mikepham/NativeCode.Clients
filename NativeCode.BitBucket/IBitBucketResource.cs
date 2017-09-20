using System;
using System.Threading.Tasks;
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
        string GetCollectionUrl([NotNull] BitBucketClientContext context);

        [NotNull]
        string GetPostUrl([NotNull] BitBucketClientContext context);

        [NotNull]
        string GetUrl([NotNull] BitBucketClientContext context);
    }

    public interface IBitBucketResource<T> : IBitBucketResource
        where T : class, new()
    {
        Task<T> GetAsync(BitBucketClientContext context);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, BitBucketClientContext context);
    }
}