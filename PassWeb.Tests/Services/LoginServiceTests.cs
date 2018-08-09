using Moq;
using NUnit.Framework;
using PassWeb.Domain.Models;
using PassWeb.Infrastructure.IRepositories;
using PassWeb.Interfaces;
using PassWeb.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassWeb.Tests.Services
{
    [TestFixture]
    public class LoginServiceTests
    {
        private readonly IUserRepository _mockRepo;

        public LoginServiceTests()
        {
            IList<User> users = new List<User>()
            {
                new User()
                {
                    EMailAddress = "o.yesilnacar@emakina.com.tr",
                    Hash = Encoding.ASCII.GetBytes("0x5F5AAC9B0953CF80D82CFE115E1E8350046FAE17CDCD9FFC3D47E62A4F58428B"),
                    HashedPassword = "X1qsmwlTz4DYLP4RXh6DUARvrhfNzZ/8PUfmKk9YQos=",
                    Id = 2,
                    Salt = "F8-E8-F9-BE-09-34-30-74-E9-D9-56-3B-5B-32-DD-BD",
                    UserName = "onur"
                }
            };

            Mock<IUserRepository> mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(p => p.GetUsers()).Returns(users);
            mockUserRepo.Setup(p => p.FindByUserName(It.IsAny<string>())).Returns((string userName) => users.Where(p => p.UserName == userName).SingleOrDefault());

            _mockRepo = mockUserRepo.Object;
        }

        [Test]
        public void AreValidUserCredentialsTest()
        {
            _mockRepo.FindByUserName("onur");
            ILoginService loginService = new LoginService(_mockRepo);
            bool correctAttempt = loginService.AreValidUserCredentials("onur", "!Q2w3e4r");

            Assert.IsTrue(correctAttempt);

            _mockRepo.FindByUserName("mahmut");
            loginService = new LoginService(_mockRepo);
            bool falseAttempt = loginService.AreValidUserCredentials("mahmut", "5t6y7u8ı");

            Assert.IsFalse(falseAttempt);
        }
    }
}
