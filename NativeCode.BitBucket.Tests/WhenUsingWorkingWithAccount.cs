using System.Threading.Tasks;
using Xunit;

namespace NativeCode.BitBucket.Tests
{
    public class WhenUsingWorkingWithAccount : IClassFixture<BitBucketClientFixture>
    {
        public WhenUsingWorkingWithAccount(BitBucketClientFixture fixture)
        {
            this.fixture = fixture;
        }

        private readonly BitBucketClientFixture fixture;

        [Fact]
        public async Task ShouldGetUserInfo()
        {
            // Arrange
            using (var client = this.fixture.CreateClient())
            {
                var context = client.CreateContext();

                // Act
                var user = await client.Users.GetAsync(context);

                // Assert
                Assert.NotNull(user);
            }
        }
    }
}