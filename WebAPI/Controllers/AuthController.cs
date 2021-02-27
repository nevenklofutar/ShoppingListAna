using Contracts;
using Entities.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegister userForRegister)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _unitOfWork.Auth.Register(userForRegister);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLogin userForLogin)
        {
            var user = await _unitOfWork.Auth.Login(userForLogin);

            if (user == null)
                return BadRequest();

            return Ok(user);
        }
    }
}
