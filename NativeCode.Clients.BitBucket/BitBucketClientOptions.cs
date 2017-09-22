namespace NativeCode.Clients.BitBucket
{
    using System;
    using System.Diagnostics;
    using System.Net;

    public class BitBucketClientOptions
    {
        private const string BitbucketPassword = "BITBUCKET_PASSWORD";

        private const string BitbucketUsername = "BITBUCKET_USERNAME";

        public BitBucketClientOptions()
        {
            try
            {
                var password = Environment.GetEnvironmentVariable(BitbucketPassword);
                var username = Environment.GetEnvironmentVariable(BitbucketUsername);

                if ((string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password)) == false)
                {
                    this.Credentials = new NetworkCredential
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
        }

        public Uri BaseAddress { get; set; }

        public NetworkCredential Credentials { get; set; }

        public BitBucketClientType ClientType { get; set; }
    }
}