using Festo.Common.Enums;
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
            return Context.Set<ORDERS>().FirstOrDefault(o => o.OrderID == orderId);
        }

        public IEnumerable<ORDERS> GetAllOrders()
        {
            return Context.Set<ORDERS>().ToList();
        }

        public IEnumerable<ORDERS> GetAllCompletedOrders()
        {
            var allOrders = Context.Set<ORDERS>().OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var completedOrders = allOrders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus == (int)OrderStatus.Complete));

            return completedOrders;
        }

        public IEnumerable<ORDERS> GetAllOrdersInProduction()
        {
            var allOrders = Context.Set<ORDERS>().OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var completedOrders = allOrders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus == (int)OrderStatus.Complete));

            return completedOrders;
        }
    }
}
