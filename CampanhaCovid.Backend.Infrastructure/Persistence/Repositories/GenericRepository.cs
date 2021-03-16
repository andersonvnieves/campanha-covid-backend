using CampanhaCovid.Backend.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Infrastructure.Persistence.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
    {
        protected readonly MongoContext _context;
        protected readonly IMongoCollection<T> DbSet;

        protected GenericRepository(MongoContext context)
        {
            _context = context;
            DbSet = _context.GetCollection<T>(typeof(T).Name);
        }

        public virtual void Add(T obj)
        {
            _context.AddCommand(async () => await DbSet.InsertOneAsync(obj));            
        }

        public virtual T GetById(Guid id)
        {
            var data = DbSet.Find(Builders<T>.Filter.Eq("_id", id));
            return data.FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll()
        {
            var all = DbSet.Find(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(T obj)
        {
            _context.AddCommand(async () =>
            {
                await DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", obj.GetId()), obj);
            });
        }

        public virtual void Remove(Guid id)
        {
            _context.AddCommand(() => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
