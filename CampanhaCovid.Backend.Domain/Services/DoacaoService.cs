using AutoMapper;
using CampanhaCovid.Backend.Domain.DTOs;
using CampanhaCovid.Backend.Domain.Entities;
using CampanhaCovid.Backend.Domain.Interfaces;
using CampanhaCovid.Backend.Domain.Interfaces.Repositories;
using CampanhaCovid.Backend.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Services
{
    public class DoacaoService : IDoacaoService
    {
        private readonly IDoacaoRepository repository;
        private IMapper mapper;
        private readonly IUnitOfWork _uow;
        public DoacaoService(IDoacaoRepository repository, IMapper mapper, IUnitOfWork uow)
        {
            this.repository = repository;
            this.mapper = mapper;
            this._uow = uow;
        }

        public async Task<IEnumerable<DoacaoDTO>> GetAllByInstitution(string id)
        {
            var retorno = await repository.GetAllByInstitutionId(id);
            return mapper.Map<IEnumerable<DoacaoDTO>>(retorno);
        }

        public async Task<DoacaoDTO> GetById(string id)
        {
            var retorno = await repository.GetById(id);
            return mapper.Map<DoacaoDTO>(retorno);
        }

        public async Task<DoacaoDTO> RegistraDoacao(DoacaoDTO dadosDto)
        {
            var dados = mapper.Map<Doacao>(dadosDto);
            dadosDto.Id = dados.Id = Guid.NewGuid().ToString();
            repository.Add(dados);
            return dadosDto;
        }
        public async Task<DoacaoDTO> AlterarDoacao(DoacaoDTO dadosDto)
        {
            var dados = mapper.Map<Doacao>(dadosDto);
            repository.Update(dados, dados.Id);
            return dadosDto;
        }
    }
}
