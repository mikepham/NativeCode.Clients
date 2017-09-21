using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Humanizer;
using NativeCode.BitBucket.Models;

namespace NativeCode.BitBucket
{
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

        public virtual Task<IEnumerable<T>> GetAllAsync(BitBucketClientContext context)
        {
            try
            {
                return this.Client.GetAllAsync<T>(this, context);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
        }

        public virtual Task<T> GetAsync(BitBucketClientContext context)
        {
            try
            {
                return this.Client.GetAsync<T>(this, context);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
        }

        public virtual Task<ResourcePagingResponse<T>> GetPageAsync(BitBucketClientContext context)
        {
            try
            {
                return this.Client.GetPageAsync<T>(this, context);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
        }

        public virtual Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, BitBucketClientContext context)
        {
            try
            {
                return this.Client.PostAsync<TRequest, TResponse>(request, this, context);
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