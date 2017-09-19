using System.Net.Http;
using System.Threading.Tasks;
using NativeCode.BitBucket.Models.V2;
using NativeCode.BitBucket.Resources;

namespace NativeCode.BitBucket
{
    public class BitBucketClient : HttpClient, IBitBucketClient
    {
        private readonly BitBucketClientOptions options;

        public BitBucketClient(BitBucketClientOptions options)
        {
            this.options = options;

            this.Branches = new BranchResource(this);
            this.Users = new UserResource(this);
        }

        public IBitBucketResource<Branch> Branches { get; }

        public IBitBucketResource<PullRequest> PullRequests { get; }

        public IBitBucketResource<Repository> Repositories { get; }

        public IBitBucketResource<Team> Teams { get; }

        public IBitBucketResource<User> Users { get; }

        public virtual Task<HttpResponseMessage> GetAsync(IBitBucketResource resource, BitBucketClientContext context)
        {
            var url = resource.GetUrl(context);
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            return this.SendAsync(request);
        }

        public virtual Task<HttpResponseMessage> PostAsync(IBitBucketResource resource, BitBucketClientContext context)
        {
            var url = resource.GetUrl(context);
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            return this.SendAsync(request);
        }
    }
}