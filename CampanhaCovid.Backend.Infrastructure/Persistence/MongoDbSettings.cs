using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Infrastructure.Persistence
{
    public class MongoDbSettings
    {
        public string connectionString { get; set; }
        public string databaseName { get; set; }
    }
}
