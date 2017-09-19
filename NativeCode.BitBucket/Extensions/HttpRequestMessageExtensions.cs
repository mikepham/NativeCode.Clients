using System.Net.Http;
using JetBrains.Annotations;

namespace NativeCode.BitBucket.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static bool NoBitBucketModel([NotNull] this HttpRequestMessage request)
        {
            return request.Content.Headers.Contains(BitBucketHeaders.ModelType) == false;
        }
    }
}