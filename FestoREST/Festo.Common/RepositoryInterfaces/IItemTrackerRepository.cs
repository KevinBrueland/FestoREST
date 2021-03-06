﻿using Festo.DataTables.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.RepositoryInterfaces
{
    public interface IItemTrackerRepository : IRepository<ITEMTRACKER>
    {
        ITEMTRACKER GetItemTrackerByItemId(int itemId);

        ITEMTRACKER GetSingleItemTrackerByOrderAndItemId(int orderId, int itemId);

        object UpdateItemTracker(ITEMTRACKER itemTracker);
    }
}
