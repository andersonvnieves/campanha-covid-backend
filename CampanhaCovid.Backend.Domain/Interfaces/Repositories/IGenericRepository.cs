using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> : IDisposable
    {
        void Add(T obj);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(Guid id);
    }
}
