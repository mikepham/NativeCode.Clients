using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NativeCode.BitBucket.Models.V2;

namespace NativeCode.BitBucket
{
    public interface IBitBucketClient : IDisposable
    {
        [NotNull]
        IBitBucketResource<Branch> Branches { get; }

        BitBucketClientType ClientType { get; }

        [NotNull]
        IBitBucketResource<PullRequest> PullRequests { get; }

        [NotNull]
        IBitBucketResource<Repository> Repositories { get; }

        [NotNull]
        IBitBucketResource<Team> Teams { get; }

        [NotNull]
        IBitBucketResource<User> Users { get; }

        [NotNull]
        BitBucketClientContext CreateContext([CanBeNull] string id = default(string), [CanBeNull] string repository = default(string));

        Task<TRequest> GetAsync<TRequest>(IBitBucketResource resource, BitBucketClientContext context);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest instance, IBitBucketResource resource, BitBucketClientContext context);
    }
}