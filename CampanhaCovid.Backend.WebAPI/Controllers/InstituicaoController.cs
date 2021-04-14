using CampanhaCovid.Backend.Domain.DTOs;
using CampanhaCovid.Backend.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class InstituicaoController : ControllerBase
    {
        private readonly IRegistraUsuarioService registraUsuarioService;
        private readonly IInstituicaoService service;

        public InstituicaoController(IInstituicaoService service, IRegistraUsuarioService registraUsuarioService)
        {
            this.service = service;
            this.registraUsuarioService = registraUsuarioService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(RegistrarInstituicaoDTO dados)
        {
            try
            {
                return Ok(await registraUsuarioService.RegistraInstituicao(dados));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var retorno = await service.GetAll();
            return Ok(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string instituicaoId)
        {
            return Ok(await service.GetById(instituicaoId));
        }
    }
}
