namespace NativeCode.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Responses;

    public interface IRestClient<TContext> : IDisposable
        where TContext : ClientContext, new()
    {
        NetworkCredential Credentials { get; }

        Task<IEnumerable<TResponse>> GetAllAsync<TResponse>(IRestResource<TContext> resource, TContext context);

        Task<TResponse> GetAsync<TResponse>(IRestResource<TContext> resource, TContext context);

        Task<PagingResponse<TResponse>> GetPageAsync<TResponse>(IRestResource<TContext> resource, TContext context);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest instance, IRestResource<TContext> resource, TContext context);
    }
}