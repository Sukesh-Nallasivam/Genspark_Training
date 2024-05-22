using Microsoft.Extensions.Configuration;
using Moq;
using RequestTracker.Interfaces;
using RequestTracker.Services;
using UserLoginTraining1705.Models;
namespace RequestTrackerTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TokenTest1()
        {
            Mock<IConfigurationSection> configurationJWTSection = new Mock<IConfigurationSection>();
            configurationJWTSection.Setup(x => x.Value).Returns("Dummy Key for token authentication_");
            Mock<IConfigurationSection> congigTokenSection = new Mock<IConfigurationSection>();
            congigTokenSection.Setup(x => x.GetSection("JWT")).Returns(configurationJWTSection.Object);
            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x => x.GetSection("TokenKey")).Returns(congigTokenSection.Object);
            ITokenService service = new TokenService(mockConfig.Object);

            //Action
            var token = service.GenerateToken(new User { UserId = 1 });

            //Assert
            Assert.IsNotNull(token);
        }
    }
}