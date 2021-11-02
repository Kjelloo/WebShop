using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kjelloo.WebShop.WebApi.DTOs.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kjelloo.WebShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult<TokenDto> Login([FromBody] LoginDto loginDto)
        {
            if ("kjello".Equals(loginDto.Username) && "123".Equals(loginDto.Password))
            {
                return Ok(new TokenDto {JwtToken = "jwttoken"});
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}