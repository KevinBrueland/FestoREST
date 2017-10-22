using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        T Get();

        void Add(T type);

        void Remove(T type);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
