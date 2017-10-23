using Festo.Common.Enums;
using Festo.Common.RepositoryInterfaces;
using Festo.Common.UtilityInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Utility.RepositoryHelpers
{
    public class RepositoryActionResult<T> : IRepositoryActionResult<T> where T : class
    {
        public T Entity { get; private set; }
        public RepositoryActionStatus Status { get; private set; }

        public Exception Exception { get; private set; }


        public RepositoryActionResult(T entity, RepositoryActionStatus status)
        {
            Entity = entity;
            Status = status;
        }

        public RepositoryActionResult(T entity, RepositoryActionStatus status, Exception exception) : this(entity, status)
        {
            Exception = exception;
        }

        public object ActionResult(T entity, RepositoryActionStatus status, Exception exception)
        {
            return new RepositoryActionResult<T>(entity, status, exception);
        }

        public object ActionResult(T entity, RepositoryActionStatus status)
        {
            return new RepositoryActionResult<T>(entity, status);
        }
    }
}
