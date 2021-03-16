using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Interfaces
{
   public interface IUnitOfWork : IDisposable
{
    bool Commit();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly IMongoContext _context;

    public UnitOfWork(IMongoContext context)
    {
        _context = context;
    }

    public bool Commit()
    {
        return _context.SaveChanges().Result > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    }
}