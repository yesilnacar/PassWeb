using AutoMapper;
using PassWeb.Dtos;
using PassWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassWeb.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _context;

        public AccountController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Login()
        {
            return View();
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
                var user = new UserDto()
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    EMailAddress = model.Email
                };

                Mapper.Map()
            }

            return View(model);
        }
    }
}