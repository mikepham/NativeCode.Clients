using System;
using System.Net;

namespace NativeCode.BitBucket
{
    public class BitBucketClientOptions
    {
        public Uri BaseUri { get; set; }

        public NetworkCredential Credentials { get; set; }

        public BitBucketClientType Type { get; set; }
    }
}