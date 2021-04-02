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
            try
            {
                doacaoService.RegsitraInstituicao(dados);
                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public IActionResult Put(DoacaoDTO dados)
        {
            return Ok("");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoacaoDTO>>> Get()
        {
            return Ok(await doacaoService.GetAll());
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(Guid id)
        //{
        //    return Ok(await doacaoService.GetById(id));
        //}
    }
}
