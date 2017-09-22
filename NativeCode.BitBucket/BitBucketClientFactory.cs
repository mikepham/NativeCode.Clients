namespace NativeCode.BitBucket
{
    using System.Net;
    using System.Net.Http;
    using JetBrains.Annotations;

    public class BitBucketClientFactory : IBitBucketClientFactory
    {
        public IBitBucketClient Create(BitBucketClientOptions options)
        {
            return new BitBucketClient(options, CreateClientHandler(options));
        }

        private static HttpMessageHandler CreateClientHandler([NotNull] BitBucketClientOptions options)
        {
            var handler = new HttpClientHandler();

            try
            {
                handler.AllowAutoRedirect = true;
                handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                handler.CookieContainer = new CookieContainer();
                handler.Credentials = options.Credentials;
                handler.PreAuthenticate = options.Credentials != null;

                return handler;
            }
            catch
            {
                handler.Dispose();
                throw;
            }
        }
    }
}