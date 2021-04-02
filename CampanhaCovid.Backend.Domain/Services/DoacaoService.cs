using AutoMapper;
using CampanhaCovid.Backend.Domain.DTOs;
using CampanhaCovid.Backend.Domain.Entities;
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
        public DoacaoService(IDoacaoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void RegsitraInstituicao(DoacaoDTO dadosDto)
        {
            var dados = mapper.Map<Doacao>(dadosDto);
            repository.Add(dados);
        }
    }
}
