using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Entities
{
    public class Instituicao
    { 
        [BsonId]
        [BsonElement("Id")]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nome")]
        public string Nome { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("telefone")]
        public string Telefone { get; set; }
        [BsonElement("cnpj")]
        public string Cnpj { get; set; }
        [BsonElement("descricao")]
        public string Descricao { get; set; }
        [BsonElement("transporte")]
        public bool Transporte { get; set; }
        public Usuario Usuario { get; set; }
        public Endereco Endereco { get; set; }
    }
}
