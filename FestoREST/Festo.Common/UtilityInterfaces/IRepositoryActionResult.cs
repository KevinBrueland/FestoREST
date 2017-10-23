using Festo.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.UtilityInterfaces
{
    public interface IRepositoryActionResult<T> where T : class
    {
        object ActionResult(T entity, RepositoryActionStatus status, Exception exception);

        object ActionResult(T entity, RepositoryActionStatus status);
    }
}
