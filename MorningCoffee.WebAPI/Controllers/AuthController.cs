using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MorningCoffee.Business.Abstract;
using MorningCoffee.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MorningCoffee.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var login = _authService.Login(userForLoginDto);
            if (!login.Success)
            {
                return BadRequest(login.Message);
            }

            var token = _authService.CreateToken(login.Data);
            if (!token.Success)
            {
                return BadRequest(token.Message);
            }
            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var register = _authService.Register(userForRegisterDto);
            if (!register.Success)
            {
                return BadRequest(register.Message);
            }

            var token = _authService.CreateToken(register.Data);
            if (!token.Success)
            {
                return BadRequest(token.Message);
            }

            return Ok(token);
        }
    }
}
