using AutoMapper;
using CampanhaCovid.Backend.Domain.DTOs;
using CampanhaCovid.Backend.Domain.Interfaces;
using CampanhaCovid.Backend.Domain.Interfaces.Repositories;
using CampanhaCovid.Backend.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Services
{
    public class InstituicaoService : IInstituicaoService
    {
        private readonly IInstituicaoRepository repository;

        private IMapper mapper;
        private readonly IUnitOfWork _uow;
        public InstituicaoService(IMapper mapper, IUnitOfWork uow, IInstituicaoRepository repository)
        {
            this.mapper = mapper;
            this._uow = uow;
            this.repository = repository;
        }

        public async Task<LogInInstituicaoDTO> LogIn(LogInInstituicaoDTO dto)
        {
            var retorno = await repository.ObterPorUsuarioSenha(dto);
            
            if (retorno == null)
                throw new Exception("Campo Usuario ou Senha: Inválido");

            return dto;
        }

        public async Task<List<InstituicaoDTO>> GetAll()
        {
            var retorno = await repository.GetAll();
            var dados = mapper.Map<List<InstituicaoDTO>>(retorno);

            return dados;
        }

        public async Task<InstituicaoDTO> GetById(string userId)
        {
            var retorno = await repository.GetById(userId);
            var dados = mapper.Map<InstituicaoDTO>(retorno);

            return dados;
        }
    }
}
