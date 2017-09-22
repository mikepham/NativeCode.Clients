namespace NativeCode.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Responses;

    public interface IRestResource<in TContext> where TContext : ClientContext, new()
    {
        [NotNull]
        string ResourceName { get; }

        [NotNull]
        Type Type { get; }

        [NotNull]
        string GetResourcePageUrl([NotNull] TContext context);

        [NotNull]
        string GetActionUrl([NotNull] TContext context);

        [NotNull]
        string GetResourceUrl([NotNull] TContext context);
    }

    public interface IRestResource<T, in TContext> : IRestResource<TContext> where TContext : ClientContext, new()
        where T : class, new()
    {
        Task<IEnumerable<T>> GetAllAsync(TContext context);

        Task<PagingResponse<T>> GetPageAsync(TContext context);

        Task<T> GetAsync(TContext context);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, TContext context);
    }
}