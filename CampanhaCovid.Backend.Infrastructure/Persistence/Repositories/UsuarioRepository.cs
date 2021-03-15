using CampanhaCovid.Backend.Domain.Entities;
using CampanhaCovid.Backend.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository<Usuario>
    {
        public void Salvar(Task entity)
        {
            throw new NotImplementedException();
        }
    }
}
