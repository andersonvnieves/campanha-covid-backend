using CampanhaCovid.Backend.Domain.Entities;
using CampanhaCovid.Backend.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Services
{
    public class RegistraUsuarioService
    {
        private readonly IUsuarioRepository<Usuario> usuarioRepository;

        public RegistraUsuarioService(IUsuarioRepository<Usuario> usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public void Executar()
        {

        }
    }
}
