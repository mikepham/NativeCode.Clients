using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NativeCode.BitBucket.Extensions;
using NativeCode.BitBucket.Models.V2;
using NativeCode.BitBucket.Resources;

namespace NativeCode.BitBucket
{
    public class BitBucketClient : HttpClient, IBitBucketClient
    {
        private readonly BitBucketClientOptions options;

        public BitBucketClient([NotNull] BitBucketClientOptions options, HttpMessageHandler handler) : base(handler)
        {
            this.options = options;
            this.BaseAddress = this.options.BaseAddress;

            this.Branches = new BranchResource(this);
            this.Users = new UserResource(this);
        }

        public IBitBucketResource<Branch> Branches { get; }

        public BitBucketClientType ClientType => this.options.ClientType;

        public IBitBucketResource<PullRequest> PullRequests { get; }

        public IBitBucketResource<Repository> Repositories { get; }

        public IBitBucketResource<Team> Teams { get; }

        public IBitBucketResource<User> Users { get; }

        public BitBucketClientContext CreateContext(string id, string repository)
        {
            return new BitBucketClientContext
            {
                ClientType = this.options.ClientType,
                IdSlug = id,
                RepoSlug = repository
            };
        }

        public async Task<IEnumerable<TResponse>> GetAllAsync<TResponse>(IBitBucketResource resource, BitBucketClientContext context)
        {
            var url = resource.GetCollectionUrl(context);
            var response = await this.GetAsync(url);

            return await DeserializeAsync<IEnumerable<TResponse>>(response);
        }

        public async Task<TResponse> GetAsync<TResponse>(IBitBucketResource resource, BitBucketClientContext context)
        {
            var url = resource.GetUrl(context);
            var response = await this.GetAsync(url);

            return await DeserializeAsync<TResponse>(response);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest instance, IBitBucketResource resource,
            BitBucketClientContext context)
        {
            var url = resource.GetPostUrl(context);
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Serialize(instance);

            var response = await this.SendAsync(request);

            return await DeserializeAsync<TResponse>(response);
        }

        private static async Task<TResponse> DeserializeAsync<TResponse>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode == false || response.Content.IsJson() == false)
            {
                throw new InvalidOperationException("Failed to retrieve JSON object.");
            }

            return await response.DeserializeAsync<TResponse>();
        }
    }
}