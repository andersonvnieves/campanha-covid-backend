using CampanhaCovid.Backend.Domain.Entities;
using CampanhaCovid.Backend.Domain.Interfaces;
using CampanhaCovid.Backend.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Infrastructure.Persistence.Repositories
{
    public class DoacaoRepository : BaseRepository<Doacao>, IDoacaoRepository
    {
        public DoacaoRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Doacao>> GetAllByInstitutionId(string id)
        {
            var data = await DbSet.FindAsync(Builders<Doacao>.Filter.Eq("idInstituicao", id));
            return data.ToList();
        }
    }
}
