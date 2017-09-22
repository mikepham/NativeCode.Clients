namespace NativeCode.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Responses;

    public interface IRestClient<TContext> : IDisposable
        where TContext : ClientContext, new()
    {
        NetworkCredential Credentials { get; }

        [NotNull]
        TContext CreateContext([CanBeNull] string id = default(string), [CanBeNull] string repository = default(string));

        Task<IEnumerable<TResponse>> GetAllAsync<TResponse>(IRestResource<TContext> resource, TContext context);

        Task<ResourcePagingResponse<TResponse>> GetPageAsync<TResponse>(IRestResource<TContext> resource, TContext context);

        Task<TResponse> GetAsync<TResponse>(IRestResource<TContext> resource, TContext context);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest instance, IRestResource<TContext> resource, TContext context);
    }
}