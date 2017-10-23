using Festo.Common.Enums;
using Festo.Common.RepositoryInterfaces;
using Festo.Utility.RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.DataAccess.ConcreteRepositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(T type)
        {
            Context.Set<T>().Add(type);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public T Get()
        {
            return Context.Set<T>().Find();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Remove(T type)
        {
            Context.Set<T>().Remove(type);
        }

        public object Insert(T entity)
        {
            try
            {
                Context.Set<T>().Add(entity);
                var result = Context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<T>(entity, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<T>(entity, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<T>(null, RepositoryActionStatus.Error, ex);
            }
        }
    }
}
