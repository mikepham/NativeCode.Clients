namespace NativeCode.BitBucket
{
    public class BitBucketClientFactory : IBitBucketClientFactory
    {
        public IBitBucketClient Create(BitBucketClientOptions options)
        {
            return new BitBucketClient(options);
        }
    }
}