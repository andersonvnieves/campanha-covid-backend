using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository<T>
    {
        void Salvar(Task entity);
    }
}
