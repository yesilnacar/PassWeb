using AutoMapper;
using PassWeb.Dtos;
using PassWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PassWeb.Controllers.Api
{
    public class AccountController : ApiController
    {
        private ApplicationDbContext _context;

        public AccountController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = Mapper.Map<UserDto, User>(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();

            userDto.Id = user.Id;
            return Created(new Uri(Request.RequestUri + "/" + user.Id), userDto);
        }
    }
}
