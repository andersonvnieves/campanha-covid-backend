using CampanhaCovid.Backend.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Interfaces.Services
{
    public interface IDoacaoService
    {
        void RegsitraInstituicao(DoacaoDTO dados);
    }
}
