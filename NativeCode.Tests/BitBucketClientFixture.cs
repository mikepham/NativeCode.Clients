namespace NativeCode.Tests
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using Clients.BitBucket;

    public class BitBucketClientFixture : IDisposable
    {
        private const string BitbucketPassword = "BITBUCKET_PASSWORD";

        private const string BitbucketUsername = "BITBUCKET_USERNAME";

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

            try
            {
                var password = Environment.GetEnvironmentVariable(BitbucketPassword);
                var username = Environment.GetEnvironmentVariable(BitbucketUsername);

                if ((string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password)) == false)
                {
                    options.Credentials = new NetworkCredential
                    {
                        Password = password,
                        UserName = username
                    };
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to get credentials from environment: {ex.Message}");
            }

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