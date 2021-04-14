using CampanhaCovid.Backend.Domain.DTOs;
using CampanhaCovid.Backend.Domain.Interfaces.Services;
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
    public class DoacaoController : ControllerBase
    {
        private readonly IDoacaoService doacaoService;

        public DoacaoController(IDoacaoService doacaoService)
        {
            this.doacaoService = doacaoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(DoacaoDTO dados)
        {
            try
            {
                return Ok(await doacaoService.RegistraDoacao(dados));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("/api/Doacao/AllByInstitution/{instituicaoId}")]
        public async Task<ActionResult<IEnumerable<DoacaoDTO>>> GetAllByInstitution(string instituicaoId)
        {
            return Ok(await doacaoService.GetAllByInstitution(instituicaoId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await doacaoService.GetById(id));
        }
    }
}
