namespace NativeCode.BitBucket
{
    public interface IBitBucketClientFactory
    {
        IBitBucketClient Create(BitBucketClientOptions options);
    }
}