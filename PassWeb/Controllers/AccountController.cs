using PassWeb.Domain.Models;
using PassWeb.Interfaces.IServices;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PassWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly ILoginService loginService;
        private readonly IPassResetTokenService passResetTokenService;
        private readonly IEmailService emailService;

        public AccountController(IUserService _userService, ILoginService _loginService, IPassResetTokenService _passResetTokenService, IEmailService _emailService)
        {
            userService = _userService;
            loginService = _loginService;
            passResetTokenService = _passResetTokenService;
            emailService = _emailService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (loginService.AreValidUserCredentials(model.UserName, model.Password))
                    return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                userService.Add(model);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userService.Find(model.Email);
                if (user == null)
                    return View("ResetPasswordConfirmation");

                string token = passResetTokenService.GenerateToken(user);
                emailService.SendEmail(new MailMessage("app@passweb.com", model.Email, "Password Reset", token));

                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}