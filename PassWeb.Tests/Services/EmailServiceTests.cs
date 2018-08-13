using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PassWeb.Domain.Models;
using PassWeb.Interfaces.IRepositories;
using PassWeb.Interfaces.IServices;
using PassWeb.Services;

namespace PassWeb.Tests.Services
{
    [TestFixture]
    public class EmailServiceTests
    {
        private readonly IUserRepository _mockUserRepo;
        private readonly IPassResetTokenRepository _mockPassResetTokenRepo;
        private readonly IPassResetTokenService passResetTokenService;

        public EmailServiceTests()
        {
            IList<User> users = new List<User>()
            {
                new User()
                {
                    EMailAddress = "foo@app.com",
                    Hash = Encoding.ASCII.GetBytes("0x5F5AAC9B0953CF80D82CFE115E1E8350046FAE17CDCD9FFC3D47E62A4F58428B"),
                    HashedPassword = "X1qsmwlTz4DYLP4RXh6DUARvrhfNzZ/8PUfmKk9YQos=",
                    Id = 2,
                    Salt = "F8-E8-F9-BE-09-34-30-74-E9-D9-56-3B-5B-32-DD-BD",
                    UserName = "onur"
                }
            };

            Mock<IUserRepository> mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(p => p.GetUsers()).Returns(users);
            mockUserRepo.Setup(p => p.FindByEmail(It.IsAny<string>())).Returns((string emailAddress) => users.Where(p => p.EMailAddress == emailAddress).SingleOrDefault());

            _mockUserRepo = mockUserRepo.Object;

            Mock<IPassResetTokenRepository> mockPassResetTokenRepo = new Mock<IPassResetTokenRepository>();
            mockPassResetTokenRepo.Setup(t => t.Add(It.IsAny<PassResetToken>()));

            _mockPassResetTokenRepo = mockPassResetTokenRepo.Object;

            passResetTokenService = new PassResetTokenService(_mockPassResetTokenRepo);
        }

        [Test]
        public void SendEmailTest()
        {
            User user = _mockUserRepo.FindByEmail("foo@app.com");

            Assert.IsNotNull(user);

            IEmailService emailService = new EmailService();
            string token = passResetTokenService.GenerateToken(user);
            emailService.SendEmail(new MailMessage("app@passweb.com", "foo@app.com", "Password Reset", token));

            Assert.IsNotEmpty(token);
        }
    }
}
