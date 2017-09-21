using Humanizer;
using Newtonsoft.Json.Serialization;

namespace NativeCode.BitBucket.JsonExtensions
{
    public class UnderscoreContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.Underscore();
        }
    }
}