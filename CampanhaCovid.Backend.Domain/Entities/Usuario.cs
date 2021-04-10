using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Entities
{
    public class Usuario
    {
        [BsonElement("login")]
        public string Login { get; set; }
        
        [BsonElement("senha")]
        public string Senha { get; set; }
    }
}
