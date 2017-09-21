using System;
using System.Net;

namespace NativeCode.BitBucket
{
    public class BitBucketClientOptions
    {
        private const string BitbucketPassword = "BITBUCKET_PASSWORD";

        private const string BitbucketUsername = "BITBUCKET_USERNAME";

        public BitBucketClientOptions()
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

        public Uri BaseAddress { get; set; }

        public NetworkCredential Credentials { get; set; }

        public BitBucketClientType ClientType { get; set; }
    }
}