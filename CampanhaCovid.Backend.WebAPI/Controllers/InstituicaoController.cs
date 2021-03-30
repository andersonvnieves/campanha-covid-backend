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
    public class InstituicaoController : ControllerBase
    {
        private readonly IRegistraUsuarioService registraUsuarioService;

        public InstituicaoController(IRegistraUsuarioService registraUsuarioService)
        {
            this.registraUsuarioService = registraUsuarioService;
        }

        [HttpPost]
        public IActionResult Post(RegistrarInstituicaoDTO dados)
        {
            registraUsuarioService.RegsitraInstituicao(dados);
            return Ok("");
        }


        [HttpPut]
        public IActionResult Put(RegistrarInstituicaoDTO dados)
        {

            return Ok("");
        }

        [HttpGet]
        public IActionResult Get(int instituicaoId)
        {
            return Ok("");
        }

        [HttpGet]
        public IActionResult GetByCidadeTransporte(bool transporte, string cidade)
        {
            var retorno = registraUsuarioService.GetByCidadeTransporte(transporte, cidade);
            return Ok(retorno);
        }
    }
}
