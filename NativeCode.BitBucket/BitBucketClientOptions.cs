using System;
using System.Net;

namespace NativeCode.BitBucket
{
    public class BitBucketClientOptions
    {
        public Uri BaseAddress { get; set; }

        public NetworkCredential Credentials { get; set; }

        public BitBucketClientType ClientType { get; set; }
    }
}