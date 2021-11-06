using System.Collections.Generic;
using Kjelloo.WebShop.WebApi.DTOs.Auth;
using Kjelloo.WebShop.WebApi.DTOs.Auth.signup;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Models;
using WebShop.Core.Services;

namespace Kjelloo.WebShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("/api/user/signup")]
        [HttpPost]
        public ActionResult Signup([FromBody] SignupDto signupDto)
        {
            var userCreate = new User
            {
                Username = signupDto.Username,
                Password = signupDto.Password
            };

            _userService.Create(userCreate);

            return Ok("User created.");
        }
        
        [Route("/api/user/signup")]
        [HttpGet]
        public ActionResult<List<GetUsers>> GetUsers()
        {
            var users = _userService.GetAll();

            if (users.Count == 0)
            {
                NotFound("No users found.");
            }

            return Ok(users);
        }

    }
}