﻿using Festo.DataTables.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.RepositoryInterfaces
{
    public interface IProductionRepository : IRepository<ORDERS>
    {
        ORDERS GetCurrentOrderInProduction();


        ITEM GetNextItemToProduce();
        

        ORDERS GetNextOrderToProduce();


        bool CheckIsOrderComplete(int orderId);

        bool CheckIsAllItemsInOrderComplete(int orderId);


    }
}
