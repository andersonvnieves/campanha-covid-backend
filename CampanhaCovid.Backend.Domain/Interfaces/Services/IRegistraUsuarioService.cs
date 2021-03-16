using CampanhaCovid.Backend.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Interfaces.Services
{
    public interface IRegistraUsuarioService
    {
        void RegsitraInstituicao(RegistrarInstituicaoDTO dados);
        List<InstituicaoDTO> GetByCidadeTransporte(bool transporte, string cidade);
    }
}
