using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Entities
{
    public class Instituicao
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }

        public string Descricao { get; set; }

        //public ICollection<> MyProperty { get; set; }

        public bool Transporte { get; set; }


        public Usuario Usuario { get; set; }
        public Endereco Endereco { get; set; }
    }
}
