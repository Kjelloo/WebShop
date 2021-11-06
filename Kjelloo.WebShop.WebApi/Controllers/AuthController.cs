using System.Linq;
using Kjelloo.WebShop.WebApi.DTOs.Auth;
using Kjelloo.WebShop.WebApi.DTOs.Auth.login;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Models;
using WebShop.Core.Services;
using WebShop.Infrastructure.Data.Repositories;

namespace Kjelloo.WebShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("/api/auth/login")]
        [HttpPost]
        public ActionResult<TokenDto> Login([FromBody] LoginDto loginDto)
        {
            var users = _userService.GetAll();

            var user = users.Select(usr => new LoginDto
            {
                Username = usr.Username,
                Password = usr.Password
            }).FirstOrDefault(dto => dto.Username == loginDto.Username && dto.Password == loginDto.Password);

            if (user != null)
            {
                return Ok(new TokenDto {JwtToken = "jwttoken"});
            }

            return Unauthorized();
        }
    }
}