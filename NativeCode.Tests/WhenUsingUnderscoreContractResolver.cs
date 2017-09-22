namespace NativeCode.Tests
{
    using Clients.JsonExtensions;
    using Newtonsoft.Json;
    using Xunit;

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