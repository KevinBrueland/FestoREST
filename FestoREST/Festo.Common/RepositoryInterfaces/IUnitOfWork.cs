using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.RepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository ORDERs { get; }

        IItemRepository ITEMs { get; }

        IOrderTrackerRepository ORDERTRACKERs { get; }

        IItemTrackerRepository ITEMTRACKERs { get; }

        IProductionRepository PRODUCTION { get; }


        int Complete();


    }
}
