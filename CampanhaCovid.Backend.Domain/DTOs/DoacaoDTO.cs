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
        public int QuantidadePecas { get; set; }
        public int IdDoador { get; set; }
        public int IdInstituicao { get; set; }
        public Status Status{ get; set; }
    }
}
