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
    public class RegistraUsuarioService : IRegistraUsuarioService
    {
        private readonly IUsuarioRepository repository;
        private readonly IInstituicaoRepository instituicaoRepository;
        private IMapper mapper;
        private readonly IUnitOfWork uow;

        public RegistraUsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IInstituicaoRepository instituicaoRepository, IUnitOfWork uow)
        {
            this.repository = usuarioRepository;
            this.mapper = mapper;
            this.instituicaoRepository = instituicaoRepository;
            this.uow = uow;
        }

        public void Executar()
        {

        }

        public List<InstituicaoDTO> GetByCidadeTransporte(bool transporte, string cidade)
        {
            //TODO Buscar instituições por cidade e se vai buscar as roupas[
            return new List<InstituicaoDTO>();
        }

        public async Task<RegistrarInstituicaoDTO> RegistraInstituicao(RegistrarInstituicaoDTO dadosDto)
        {
            var dados = mapper.Map<Instituicao>(dadosDto);
            dadosDto.Id = dados.Id = Guid.NewGuid().ToString();
            instituicaoRepository.Add(dados);
            await uow.Commit();
            return dadosDto;
        }
    }
}
