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
    public class ProductionRepository : Repository<ORDERS>, IProductionRepository
    {
        public ProductionRepository(FestoContext context) : base(context)
        {

        }

        public FestoContext FestoContext
        {
            get { return Context as FestoContext; }
        }

        public ORDERS GetCurrentOrderInProduction()
        {
            var orders = Context.Set<ORDERS>().OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var firstOrder = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete &&
                                               o.ORDERTRACKER.Any(ot2 => ot2.OrderStatus == (int)OrderStatus.InProduction)))
                                               .FirstOrDefault();

            return firstOrder;
        }


        public ITEM GetNextItemToProduce()
        {
            var firstOrder = GetFirstOrderInProductionAndNotCompleted();

            var items = Context.Set<ITEM>().Where(i => i.OrderID == firstOrder.OrderID) as IQueryable<ITEM>;

            var nextItem = CheckStatusOfItems(items);

            return nextItem;
        }

        private ITEM CheckStatusOfItems(IQueryable<ITEM> items)
        {
            var ItemsToProduce =
                                 from item in items
                                 from lastStatusOfItem in Context.Set<ITEMTRACKER>()
                                .Where(it => it.ItemID == item.ItemID)
                                .OrderByDescending(it => it.ItemTrackerID)
                                .Take(1)
                                 where (lastStatusOfItem.ItemStatus == (int)ItemStatus.Failed || lastStatusOfItem.ItemStatus == (int)ItemStatus.Confirmed)
                                 select item;

            return ItemsToProduce.FirstOrDefault();

        }

        public ORDERS GetFirstOrderInProductionAndNotCompleted()
        {

            var orders = Context.Set<ORDERS>().OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var firstOrder = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete
                                            && o.ORDERTRACKER.Any(ot2 => ot2.OrderStatus == (int)OrderStatus.InProduction))).FirstOrDefault();

            return firstOrder;

        }





        public ORDERS GetNextOrderToProduce()
        {
            var orders = Context.Set<ORDERS>().OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var nextOrderToProduce = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete &&
                                                                                ot.OrderStatus != (int)OrderStatus.InProduction))
                                                                                .FirstOrDefault();

            return nextOrderToProduce;
        }

        public bool CheckIsOrderComplete(int orderId)
        {
            var isComplete = Context.Set<ORDERS>().Any(o => o.OrderID == orderId && o.ORDERTRACKER.
                                                   Any(ot => ot.OrderStatus == (int)OrderStatus.Complete));

            return isComplete;
        }

        public bool CheckIsAllItemsInOrderComplete(int orderId)
        {

            var items = Context.Set<ITEM>().Where(i => i.OrderID == orderId) as IQueryable<ITEM>;

            var itemTrackers = Context.Set<ITEMTRACKER>().Where(i => i.OrderID == orderId && i.ItemStatus == (int)ItemStatus.Complete) as IQueryable<ITEMTRACKER>;

            if(items.Count() == itemTrackers.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            

    }
}
