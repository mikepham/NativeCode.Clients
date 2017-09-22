namespace NativeCode.Tests
{
    using System;
    using Clients.BitBucket;

    public class BitBucketClientFixture : IDisposable
    {
        private readonly IBitBucketClientFactory factory = new BitBucketClientFactory();

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IBitBucketClient CreateClient()
        {
            var options = new BitBucketClientOptions
            {
                BaseAddress = new Uri("https://api.bitbucket.org"),
                ClientType = BitBucketClientType.ApiV2
            };

            return this.factory.Create(options);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
    }
}