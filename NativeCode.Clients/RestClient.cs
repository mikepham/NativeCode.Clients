namespace NativeCode.Clients
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Responses;

    public abstract class RestClient<TContext> : HttpClient, IRestClient<TContext>
        where TContext : ClientContext, new()
    {
        public abstract NetworkCredential Credentials { get; }

        public abstract Task<IEnumerable<TResponse>> GetAllAsync<TResponse>(IRestResource<TContext> resource, TContext context);

        public abstract Task<TResponse> GetAsync<TResponse>(IRestResource<TContext> resource, TContext context);

        public abstract Task<PagingResponse<TResponse>> GetPageAsync<TResponse>(IRestResource<TContext> resource, TContext context);

        public abstract Task<TResponse> PostAsync<TRequest, TResponse>(TRequest instance, IRestResource<TContext> resource,
            TContext context);
    }
}