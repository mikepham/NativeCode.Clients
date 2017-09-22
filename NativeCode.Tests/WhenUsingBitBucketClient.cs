namespace NativeCode.Tests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class WhenUsingBitBucketClient : IClassFixture<BitBucketClientFixture>
    {
        public WhenUsingBitBucketClient(BitBucketClientFixture fixture)
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
                Assert.Equal(client.Credentials.UserName, user.Username);
            }
        }
        
        [Fact]
        public async Task ShouldGetListOfBranches()
        {
            // Arrange
            using (var client = this.fixture.CreateClient())
            {
                var context = client.CreateContext("plsos2", "plsos2");

                // Act
                var branches = await client.Branches.GetAllAsync(context);

                // Assert
                Assert.True(branches.Any());
            }
        }
        
        [Fact]
        public async Task ShouldGetListOfPullRequests()
        {
            // Arrange
            using (var client = this.fixture.CreateClient())
            {
                var context = client.CreateContext("plsos2", "plsos2");

                // Act
                var pullRequests = await client.PullRequests.GetAllAsync(context);

                // Assert
                Assert.NotNull(pullRequests);
            }
        }
    }
}