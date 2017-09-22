namespace NativeCode.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Humanizer;
    using Responses;

    public abstract class RestResource<T, TContext> : IRestResource<T, TContext>
        where T : class, new()
        where TContext : ClientContext, new()
    {
        protected RestResource(IRestClient<TContext> client)
        {
            this.Client = client;
        }

        protected IRestClient<TContext> Client { get; }

        public virtual string ResourceName => typeof(T).Name.Camelize();

        public virtual Type Type => typeof(T);

        public virtual async Task<IEnumerable<T>> GetAllAsync(TContext context)
        {
            try
            {
                return await this.Client.GetAllAsync<T>(this, context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
        }

        public virtual async Task<T> GetAsync(TContext context)
        {
            try
            {
                return await this.Client.GetAsync<T>(this, context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
        }

        public virtual async Task<PagingResponse<T>> GetPageAsync(TContext context)
        {
            try
            {
                return await this.Client.GetPageAsync<T>(this, context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
        }

        public virtual async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, TContext context)
        {
            try
            {
                return await this.Client.PostAsync<TRequest, TResponse>(request, this, context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
        }

        public abstract string GetActionUrl(TContext context);

        public abstract string GetResourcePageUrl(TContext context);

        public abstract string GetResourceUrl(TContext context);
    }
}