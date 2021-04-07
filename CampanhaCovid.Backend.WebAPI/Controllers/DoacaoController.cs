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
                return Ok(doacaoService.RegsitraDoacao(dados));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public IActionResult Put(DoacaoDTO dados)
        {
            try
            {
                return Ok(doacaoService.AlterarDoacao(dados));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoacaoDTO>>> Get()
        {
            return Ok(await doacaoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await doacaoService.GetById(id));
        }
    }
}
