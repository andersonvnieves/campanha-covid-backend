using CampanhaCovid.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Interfaces.Repositories
{
    public interface IDoacaoRepository : IRepository<Doacao>
    {
        Task<IEnumerable<Doacao>> GetAllByInstitutionId(string id);
    }
}
