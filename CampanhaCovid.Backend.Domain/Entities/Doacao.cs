using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static CampanhaCovid.Backend.Domain.Enum.Enumerador;

namespace CampanhaCovid.Backend.Domain.Entities
{
    public class Doacao
    {
        [BsonId]
        [BsonElement("Id")]
        public string Id { get; set; }

        [BsonElement("quantidadePecas")]
        public int QuantidadePecas { get; set; }

        [BsonElement("idDoador")]
        public int IdDoador { get; set; }

        [BsonElement("idInstituicao")]
        public int IdInstituicao { get; set; }

        [BsonElement("status")]
        public Status Status { get; set; }
    }
}
