using CampanhaCovid.Backend.Domain.DTOs;
using CampanhaCovid.Backend.Domain.Entities;
using CampanhaCovid.Backend.Domain.Interfaces;
using CampanhaCovid.Backend.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Infrastructure.Persistence.Repositories
{
    public class InstituicaoRepository : BaseRepository<Instituicao>, IInstituicaoRepository
    {
        IMongoContext context;
        public InstituicaoRepository(IMongoContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Instituicao> ObterPorUsuarioSenha(LogInInstituicaoDTO dto)
        {
            var data = await DbSet.FindAsync(
                Builders<Instituicao>.Filter.And(Builders<Instituicao>.Filter.Where(p => p.Usuario.Login.ToLower() == dto.userName.ToLower()),
                Builders<Instituicao>.Filter.Where(p => p.Usuario.Senha.ToLower() == dto.password.ToLower())));
            return data.SingleOrDefault();
        }
    }
}
