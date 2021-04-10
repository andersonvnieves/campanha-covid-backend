using CampanhaCovid.Backend.Domain.DTOs;
using CampanhaCovid.Backend.Domain.Interfaces.Services;
using CampanhaCovid.Backend.WebAPI.Configuracao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IInstituicaoService service;
        private readonly AppSettings _appSettings;

        public AutenticacaoController(IInstituicaoService service, IOptions<AppSettings> appSettings)
        {
            this.service = service;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LogInInstituicaoDTO model)
        {
            var user = await service.LogIn(model);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.userName.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.userName,
                Token = tokenString
            });
        }

        //[HttpPost]
        //public IActionResult LogOutInstituicao(LogInInstituicaoDTO dto)
        //{
        //    return Ok();
        //}

    }
}
