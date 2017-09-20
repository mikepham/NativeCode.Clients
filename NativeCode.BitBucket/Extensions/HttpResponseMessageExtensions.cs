using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NativeCode.BitBucket.ContractResolvers;
using Newtonsoft.Json;

namespace NativeCode.BitBucket.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> DeserializeAsync<T>([NotNull] this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode == false || response.Content.IsJson() == false)
            {
                throw new InvalidOperationException("Invalid request parameters to deserialize.");
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content, SerializationOptions.Settings);
        }
    }
}