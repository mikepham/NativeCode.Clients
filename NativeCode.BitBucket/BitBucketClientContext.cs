namespace NativeCode.BitBucket
{
    public class BitBucketClientContext
    {
        public string IdSlug { get; set; }
        
        public string RepoSlug { get; set; }
        
        public BitBucketClientType ClientType { get; set; }
    }
}