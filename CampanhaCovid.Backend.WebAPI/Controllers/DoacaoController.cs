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
        public IActionResult Post(DoacaoDTO dados)
        {
            //doacaoService.RegsitraInstituicao(dados);
            return Ok("");
        }


        [HttpPut]
        public IActionResult Put(DoacaoDTO dados)
        {
            return Ok("");
        }

        [HttpGet]
        public IActionResult Get(int instituicaoId)
        {
            return Ok("");
        }
    }
}
