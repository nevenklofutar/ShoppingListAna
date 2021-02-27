using AutoMapper;
using Contracts;
using Entities.Commands;
using Entities.DTOs;
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
        private readonly IMapper _mapper;

        public AuthController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _unitOfWork.Auth.Login(userForLogin);

            if (user == null)
                return BadRequest();

            var userDTO = _mapper.Map<UserDTO>(user);

            return Ok(userDTO);
        }
    }
}
