using System.Collections.Generic;
using NativeCode.BitBucket.Models.V2;

namespace NativeCode.BitBucket
{
    public class BitBucketClientContext
    {
        public string BranchSlug { get; set; }
        
        public BitBucketClientType ClientType { get; set; }
        
        public string IdSlug { get; set; }
        
        public IDictionary<string, string> Parameters { get; } = new Dictionary<string, string>();
        
        public string PullRequestSlug { get; set; }
        
        public string RepoSlug { get; set; }
        
        public ResourceType ResourceType { get; set; }
    }
}