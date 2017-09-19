using Humanizer;
using Newtonsoft.Json.Serialization;

namespace NativeCode.BitBucket.ContractResolvers
{
    public class UnderscoreContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.Underscore();
        }
    }
}