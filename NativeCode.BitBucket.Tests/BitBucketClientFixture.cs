using System;
using System.Net;

namespace NativeCode.BitBucket.Tests
{
    public class BitBucketClientFixture : IDisposable
    {
        private readonly IBitBucketClientFactory factory = new BitBucketClientFactory();

        public IBitBucketClient CreateClient()
        {
            var options = new BitBucketClientOptions
            {
                BaseAddress = new Uri("https://api.bitbucket.org"),
                Credentials = new NetworkCredential("mikepham-proplogix", "XwdZuLARwLH43YvUEnEA"),
                ClientType = BitBucketClientType.ApiV2,
            };
            
            return this.factory.Create(options);
        }
        
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }
        }
    }
}