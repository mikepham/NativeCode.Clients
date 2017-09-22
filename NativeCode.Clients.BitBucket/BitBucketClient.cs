namespace NativeCode.Clients.BitBucket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Extensions;
    using JetBrains.Annotations;
    using Resources;
    using Responses;

    public class BitBucketClient : HttpClient, IBitBucketClient
    {
        private readonly BitBucketClientOptions options;

        public BitBucketClient([NotNull] BitBucketClientOptions options, HttpMessageHandler handler = default(HttpMessageHandler))
            : base(handler, handler != default(HttpMessageHandler))
        {
            this.options = options;

            if (this.options.Credentials != null)
            {
                this.DefaultRequestHeaders.Authorization = CreateAuthorization(this.options.Credentials);
            }

            this.BaseAddress = this.options.BaseAddress;
            this.Branches = new BranchResource(this);
            this.PullRequests = new PullRequestResource(this);
            this.Teams = new TeamResource(this);
            this.Users = new UserResource(this);
        }

        public BranchResource Branches { get; }

        public BitBucketClientType ClientType => this.options.ClientType;

        public NetworkCredential Credentials => this.options.Credentials;

        public PullRequestResource PullRequests { get; }

        public TeamResource Teams { get; }

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

        public async Task<IEnumerable<TResponse>> GetAllAsync<TResponse>(IRestResource<BitBucketClientContext> resource,
            BitBucketClientContext context)
        {
            var results = new List<TResponse>(200);
            var url = this.BuildUri(context, () => resource.GetResourcePageUrl(context));

            var response = await this.GetAsync(url.Uri).ConfigureAwait(false);
            var page = await response.DeserializeAsync<ResourcePagingResponse<TResponse>>().ConfigureAwait(false);
            results.AddRange(page.Values);

            while (page.Next.HasValue())
            {
                response = await this.GetAsync(page.Next).ConfigureAwait(false);
                page = await response.DeserializeAsync<ResourcePagingResponse<TResponse>>().ConfigureAwait(false);
                results.AddRange(page.Values);
            }

            return results;
        }

        public async Task<ResourcePagingResponse<TResponse>> GetPageAsync<TResponse>(IRestResource<BitBucketClientContext> resource,
            BitBucketClientContext context)
        {
            var url = this.BuildUri(context, () => resource.GetResourcePageUrl(context));
            var response = await this.GetAsync(url.Uri).ConfigureAwait(false);

            return await response.DeserializeAsync<ResourcePagingResponse<TResponse>>().ConfigureAwait(false);
        }

        public async Task<TResponse> GetAsync<TResponse>(IRestResource<BitBucketClientContext> resource, BitBucketClientContext context)
        {
            var url = this.BuildUri(context, () => resource.GetResourceUrl(context));
            var response = await this.GetAsync(url.Uri).ConfigureAwait(false);

            return await response.DeserializeAsync<TResponse>().ConfigureAwait(false);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest instance, IRestResource<BitBucketClientContext> resource,
            BitBucketClientContext context)
        {
            var url = this.BuildUri(context, () => resource.GetActionUrl(context));
            var request = new HttpRequestMessage(HttpMethod.Post, url.Uri);
            request.Serialize(instance);

            var response = await this.SendAsync(request).ConfigureAwait(false);

            return await response.DeserializeAsync<TResponse>().ConfigureAwait(false);
        }

        protected static AuthenticationHeaderValue CreateAuthorization(NetworkCredential credentials)
        {
            var auth = $"{credentials.UserName}:{credentials.Password}";
            var bytes = Encoding.UTF8.GetBytes(auth);
            var encoded = Convert.ToBase64String(bytes);
            return new AuthenticationHeaderValue("Basic", encoded);
        }

        protected UriBuilder BuildUri(BitBucketClientContext context, Func<string> path)
        {
            return new UriBuilder(this.BaseAddress)
            {
                Path = path(),
                Query = string.Join(string.Empty, context.Parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"))
            };
        }
    }
}