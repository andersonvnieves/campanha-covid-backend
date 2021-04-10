using CampanhaCovid.Backend.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        [HttpPost]
        public IActionResult LogInInstituicao(LogInInstituicaoDTO dto)
        {
            return Ok();
        }
    }
}
