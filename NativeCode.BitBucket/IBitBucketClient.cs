using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NativeCode.BitBucket.Models;
using NativeCode.BitBucket.Models.V2;
using NativeCode.BitBucket.Resources;

namespace NativeCode.BitBucket
{
    public interface IBitBucketClient : IDisposable
    {
        [NotNull]
        BranchResource Branches { get; }

        BitBucketClientType ClientType { get; }
        
        NetworkCredential Credentials { get; }

        [NotNull]
        IBitBucketResource<PullRequest> PullRequests { get; }

        [NotNull]
        IBitBucketResource<Repository> Repositories { get; }

        [NotNull]
        IBitBucketResource<Team> Teams { get; }

        [NotNull]
        UserResource Users { get; }

        [NotNull]
        BitBucketClientContext CreateContext([CanBeNull] string id = default(string), [CanBeNull] string repository = default(string));

        Task<IEnumerable<TResponse>> GetAllAsync<TResponse>(IBitBucketResource resource, BitBucketClientContext context);

        Task<ResourcePagingResponse<TResponse>> GetPageAsync<TResponse>(IBitBucketResource resource, BitBucketClientContext context);

        Task<TResponse> GetAsync<TResponse>(IBitBucketResource resource, BitBucketClientContext context);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest instance, IBitBucketResource resource, BitBucketClientContext context);
    }
}