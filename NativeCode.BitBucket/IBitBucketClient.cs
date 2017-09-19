using System;
using NativeCode.BitBucket.Models.V2;

namespace NativeCode.BitBucket
{
    public interface IBitBucketClient : IDisposable
    {
        IBitBucketResource<Branch> Branches { get; }

        IBitBucketResource<PullRequest> PullRequests { get; }

        IBitBucketResource<Repository> Repositories { get; }

        IBitBucketResource<Team> Teams { get; }

        IBitBucketResource<User> Users { get; }
    }
}