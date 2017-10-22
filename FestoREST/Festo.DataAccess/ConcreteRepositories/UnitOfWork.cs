using Festo.Common.RepositoryInterfaces;
using Festo.DataTables.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.DataAccess.ConcreteRepositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FestoContext _context;

        public IOrderRepository ORDERs { get; private set; }

        public UnitOfWork(FestoContext context)
        {
            _context = context;

            ORDERs = new OrderRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
