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
    public class RegistraUsuarioService : IRegistraUsuarioService
    {
        private readonly IUsuarioRepository repository;

        public RegistraUsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.repository = usuarioRepository;
        }

        public void Executar()
        {

        }

        public List<InstituicaoDTO> GetByCidadeTransporte(bool transporte, string cidade)
        {
            //TODO Buscar instituições por cidade e se vai buscar as roupas[
            return new List<InstituicaoDTO>();
        }

        public void RegsitraInstituicao(RegistrarInstituicaoDTO dados)
        {
            //usuarioRepository.Salvar(dados);
            throw new NotImplementedException();
        }
    }
}
