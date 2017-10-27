﻿using Festo.Common.Enums;
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
            var firstOrder = GetCurrentOrderInProduction();

            var items = Context.Set<ITEM>().Where(i => i.OrderID == firstOrder.OrderID) as IQueryable<ITEM>;

            var nextItemToProduce = items.Where(i => i.ITEMTRACKER.All(it => it.ItemStatus == (int)ItemStatus.Failed)
                                                  || i.ITEMTRACKER.All(it2 => it2.ItemStatus != (int)ItemStatus.InProduction)
                                                  && i.ITEMTRACKER.Any(it3 => it3.ItemStatus != (int)ItemStatus.Complete)).FirstOrDefault();

            return nextItemToProduce;
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
    }
}
