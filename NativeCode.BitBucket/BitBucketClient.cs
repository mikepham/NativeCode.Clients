using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NativeCode.BitBucket.Extensions;
using NativeCode.BitBucket.Models;
using NativeCode.BitBucket.Models.V2;
using NativeCode.BitBucket.Resources;

namespace NativeCode.BitBucket
{
    public class BitBucketClient : HttpClient, IBitBucketClient
    {
        private readonly BitBucketClientOptions options;

        public BitBucketClient([NotNull] BitBucketClientOptions options, HttpMessageHandler handler) : base(handler, true)
        {
            this.options = options;
            this.BaseAddress = this.options.BaseAddress;
            
            if (this.options.Credentials != null)
            {
                this.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", BasicAuth(this.options.Credentials));
            }

            this.Branches = new BranchResource(this);
            this.Users = new UserResource(this);
        }

        public BranchResource Branches { get; }

        public BitBucketClientType ClientType => this.options.ClientType;

        public IBitBucketResource<PullRequest> PullRequests { get; }

        public IBitBucketResource<Repository> Repositories { get; }

        public IBitBucketResource<Team> Teams { get; }

        public UserResource Users { get; }

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
            var results = new List<TResponse>(200);
            var url = this.BuildUri(context, () => resource.GetResourcePageUrl(context));

            var response = await this.GetAsync(url.Uri);
            var page = await this.DeserializeAsync<ResourcePagingResponse<TResponse>>(response);
            results.AddRange(page.Values);

            while (string.IsNullOrWhiteSpace(page.Next) == false)
            {
                response = await this.GetAsync(page.Next);
                page = await this.DeserializeAsync<ResourcePagingResponse<TResponse>>(response);
                results.AddRange(page.Values);
            }

            return results;
        }

        public async Task<ResourcePagingResponse<TResponse>> GetPageAsync<TResponse>(IBitBucketResource resource,
            BitBucketClientContext context)
        {
            var url = this.BuildUri(context, () => resource.GetResourcePageUrl(context));
            var response = await this.GetAsync(url.Uri);

            return await this.DeserializeAsync<ResourcePagingResponse<TResponse>>(response);
        }

        public async Task<TResponse> GetAsync<TResponse>(IBitBucketResource resource, BitBucketClientContext context)
        {
            var url = this.BuildUri(context, () => resource.GetResourceUrl(context));
            var response = await this.GetAsync(url.Uri);

            return await this.DeserializeAsync<TResponse>(response);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest instance, IBitBucketResource resource,
            BitBucketClientContext context)
        {
            var url = this.BuildUri(context, () => resource.GetActionUrl(context));
            var request = new HttpRequestMessage(HttpMethod.Post, url.Uri);
            request.Serialize(instance);

            var response = await this.SendAsync(request);

            return await this.DeserializeAsync<TResponse>(response);
        }

        protected static string BasicAuth(NetworkCredential credentials)
        {
            var auth = $"{credentials.UserName}:{credentials.Password}";
            var bytes = Encoding.UTF8.GetBytes(auth);
            return Convert.ToBase64String(bytes);
        }

        protected UriBuilder BuildUri(BitBucketClientContext context, Func<string> path)
        {
            return new UriBuilder(this.BaseAddress)
            {
                Path = path(),
                Query = string.Join(string.Empty, context.Parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"))
            };
        }

        protected virtual async Task<TResponse> DeserializeAsync<TResponse>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode == false || response.Content.IsJson() == false)
            {
                throw new InvalidOperationException($"Failed to retrieve JSON object: {response.ReasonPhrase}");
            }

            return await response.DeserializeAsync<TResponse>();
        }
    }
}