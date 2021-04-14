using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CampanhaCovid.Backend.Domain.Enum.Enumerador;

namespace CampanhaCovid.Backend.Domain.DTOs
{
    public class DoacaoDTO
    {
        public string Id { get; set; }
        public int QuantidadePecas { get; set; }
        public string NomeCompeltoDoador { get; set; }
        public string EmailDoador { get; set; }
        public string IdInstituicao { get; set; }
        public Boolean Transporte { get; set; }
    }
}
