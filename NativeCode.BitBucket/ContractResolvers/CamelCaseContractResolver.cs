using Humanizer;
using Newtonsoft.Json.Serialization;

namespace NativeCode.BitBucket.ContractResolvers
{
    public class CamelCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.Camelize();
        }
    }
}