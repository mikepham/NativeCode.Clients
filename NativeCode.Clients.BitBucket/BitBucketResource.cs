namespace NativeCode.Clients.BitBucket
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Humanizer;
    using Models;

    public abstract class BitBucketResource<T> : IBitBucketResource<T>
        where T : class, new()
    {
        protected BitBucketResource(IBitBucketClient client)
        {
            this.Client = client;
        }

        protected IBitBucketClient Client { get; }

        public virtual string ResourceName => typeof(T).Name.Camelize();

        public virtual Type Type => typeof(T);

        public virtual async Task<IEnumerable<T>> GetAllAsync(BitBucketClientContext context)
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

        public virtual async Task<T> GetAsync(BitBucketClientContext context)
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

        public virtual async Task<ResourcePagingResponse<T>> GetPageAsync(BitBucketClientContext context)
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

        public virtual async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, BitBucketClientContext context)
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

        public abstract string GetActionUrl(BitBucketClientContext context);

        public abstract string GetResourcePageUrl(BitBucketClientContext context);

        public abstract string GetResourceUrl(BitBucketClientContext context);
    }
}