using NativeCode.BitBucket.ContractResolvers;
using Newtonsoft.Json;
using Xunit;

namespace NativeCode.BitBucket.Tests
{
    public class WhenUsingUnderscoreContractResolver
    {
        public class SimpleClass
        {
            public string CamelCaseName { get; set; }
        }

        [Fact]
        public void ShouldConvertFromJsonToPropertyName()
        {
            // Arrange
            var serializer = new JsonSerializerSettings
            {
                ContractResolver = new UnderscoreContractResolver()
            };

            var sut = new SimpleClass();

            // Act
            JsonConvert.DefaultSettings = () => serializer;

            var json = JsonConvert.SerializeObject(sut);

            // Assert
            Assert.True(json.Contains("camel_case_name"));
        }
    }
}