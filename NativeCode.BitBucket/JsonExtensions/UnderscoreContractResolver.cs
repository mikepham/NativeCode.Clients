namespace NativeCode.BitBucket.JsonExtensions
{
    using Humanizer;
    using Newtonsoft.Json.Serialization;

    public class UnderscoreContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.Underscore();
        }
    }
}