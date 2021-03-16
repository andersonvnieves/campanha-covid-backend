using CampanhaCovid.Backend.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Infrastructure.Persistence
{
    public class MongoContext: IMongoContext
    {
        //https://www.brunobrito.net.br/aspnet-core-mongodb-unit-of-work/
        private IMongoDatabase Database { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _commands;
        public IClientSessionHandle Session { get; set; }

        public MongoContext(MongoDbSettings configuration)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            _commands = new List<Func<Task>>();

            RegisterConventions();

            MongoClient = new MongoClient(configuration.connectionString);
            Database = MongoClient.GetDatabase(configuration.databaseName);
        }

        private void RegisterConventions()
        {
            var pack = new ConventionPack
        {
            new IgnoreExtraElementsConvention(true),
            new IgnoreIfDefaultConvention(true)
        };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }

        public async Task<int> SaveChanges()
        {
            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            while (Session != null && Session.IsInTransaction)
                Thread.Sleep(TimeSpan.FromMilliseconds(100));

            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }
    }
}
