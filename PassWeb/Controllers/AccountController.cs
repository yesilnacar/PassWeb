using PassWeb.Domain.Models;
using PassWeb.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PassWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly ILoginService loginService;

        public AccountController(IUserService _userService, ILoginService _loginService)
        {
            userService = _userService;
            loginService = _loginService;
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
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userService.Find(model.Email);
                if (user == null)
                    return View("ResetPasswordConfirmation");

                //string token = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                //var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = token }, protocol: Request.Url.Scheme);
                //await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
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