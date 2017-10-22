using Festo.DataTables.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.RepositoryInterfaces
{
    public interface IOrderRepository : IRepository<ORDERS>
    {
        ORDERS GetOrderByOrderId(int orderId);

        IEnumerable<ORDERS> GetAllOrders();
    }
}
