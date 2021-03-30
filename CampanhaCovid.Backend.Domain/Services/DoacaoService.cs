using CampanhaCovid.Backend.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Services
{
    public class DoacaoService : IDoacaoService
    {
        private readonly IDoacaoService doacaoRepository;

        public DoacaoService(IDoacaoService doacaoRepository)
        {
            this.doacaoRepository = doacaoRepository;
        }
    }
}
