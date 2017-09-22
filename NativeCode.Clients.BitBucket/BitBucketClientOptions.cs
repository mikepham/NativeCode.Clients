namespace NativeCode.Clients.BitBucket
{
    using System;
    using System.Net;

    public class BitBucketClientOptions
    {
        public Uri BaseAddress { get; set; }

        public NetworkCredential Credentials { get; set; }

        public BitBucketClientType ClientType { get; set; }
    }
}