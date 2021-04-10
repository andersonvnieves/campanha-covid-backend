using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Entities
{
    public class Endereco
    {
        [BsonElement("logradouro")]
        public string Logradouro { get; set; }
        [BsonElement("cep")]
        public string Cep { get; set; }
        [BsonElement("bairro")]
        public string Bairro { get; set; }
        [BsonElement("cidade")]
        public string Cidade { get; set; }
        [BsonElement("uf")]
        public string Uf { get; set; }
        [BsonElement("numero")]
        public int Numero { get; set; }
        [BsonElement("complemento")]
        public string Complemento { get; set; }
    }
}
