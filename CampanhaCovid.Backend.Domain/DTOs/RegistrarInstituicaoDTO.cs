using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.DTOs
{
    public class RegistrarInstituicaoDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }
        public string Descricao { get; set; }
        public bool Transporte { get; set; }
        public string UsuarioLogin { get; set; }
        public string UsuarioSenha { get; set; }
        public string EnderecoLogradouro { get; set; }
        public string EnderecoCep { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoUf { get; set; }
        public int EnderecoNumero { get; set; }
        public string EnderecoComplemento { get; set; }
    }
}
