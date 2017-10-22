using Festo.Common.RepositoryInterfaces;
using Festo.DataTables.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.DataAccess.ConcreteRepositories
{
    public class OrderRepository : Repository<ORDERS>, IOrderRepository
    {
        public OrderRepository(FestoContext context) : base(context)
        {

        }

        public FestoContext FestoContext
        {
            get { return Context as FestoContext; }
        }

        public ORDERS GetOrderByOrderId(int orderId)
        {
            return FestoContext.ORDERS.FirstOrDefault(o => o.OrderID == orderId);
        }

        public IEnumerable<ORDERS> GetAllOrders()
        {
            return Context.Set<ORDERS>().ToList();
        }
    }
}
