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
    public class InstituicaoRepository : BaseRepository<Instituicao>, IInstituicaoRepository
    {
        public InstituicaoRepository(IMongoContext context) : base(context)
        {
        }
    }
}
