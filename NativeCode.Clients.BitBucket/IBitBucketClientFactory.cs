namespace NativeCode.Clients.BitBucket
{
    public interface IBitBucketClientFactory
    {
        IBitBucketClient Create(BitBucketClientOptions options);
    }
}