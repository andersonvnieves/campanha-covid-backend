using AutoMapper;
using CampanhaCovid.Backend.Domain.DTOs;
using CampanhaCovid.Backend.Domain.Entities;
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

        public async Task<IEnumerable<DoacaoDTO>> GetAll()
        {
            var retorno = await repository.GetAll();
            return mapper.Map<IEnumerable<DoacaoDTO>>(retorno);
        }

        public Task<DoacaoDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task RegsitraInstituicao(DoacaoDTO dadosDto)
        {
            var dados = mapper.Map<Doacao>(dadosDto);
            dados.Id = MongoDB.Bson.ObjectId.GenerateNewId();
            repository.Add(dados);
            await _uow.Commit();
        }
    }
}
