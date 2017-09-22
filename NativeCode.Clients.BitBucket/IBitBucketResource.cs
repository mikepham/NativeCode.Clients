namespace NativeCode.Clients.BitBucket
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Models;

    public interface IBitBucketResource
    {
        [NotNull]
        string ResourceName { get; }

        [NotNull]
        Type Type { get; }

        [NotNull]
        string GetResourcePageUrl([NotNull] BitBucketClientContext context);

        [NotNull]
        string GetActionUrl([NotNull] BitBucketClientContext context);

        [NotNull]
        string GetResourceUrl([NotNull] BitBucketClientContext context);
    }

    public interface IBitBucketResource<T> : IBitBucketResource
        where T : class, new()
    {
        Task<IEnumerable<T>> GetAllAsync(BitBucketClientContext context);

        Task<ResourcePagingResponse<T>> GetPageAsync(BitBucketClientContext context);

        Task<T> GetAsync(BitBucketClientContext context);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, BitBucketClientContext context);
    }
}