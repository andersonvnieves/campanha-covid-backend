using CampanhaCovid.Backend.Domain.DTOs;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Interfaces.Services
{
    public interface IDoacaoService
    {
        Task<DoacaoDTO> RegsitraDoacao(DoacaoDTO dados);
        Task<DoacaoDTO> AlterarDoacao(DoacaoDTO dados);
        Task<DoacaoDTO> GetById(string id);
        Task<IEnumerable<DoacaoDTO>> GetAll();
    }
}
