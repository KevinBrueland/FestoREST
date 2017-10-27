using Festo.Common.DataMapperInterfaces;
using Festo.DataTables.Tables;
using Festo.DTOs;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Utility.DataMappers
{
    public class ItemTrackerMapper : BaseMapper<ITEMTRACKER,ItemTrackerDTO>, IItemTrackerMapper
    {
        public ItemTrackerDTO CreateItemTrackerDTOFromItemTracker(ITEMTRACKER itemTracker)
        {
            return new ItemTrackerDTO()
            {
                ItemTrackerID = itemTracker.ItemTrackerID,
                ItemID = itemTracker.ItemID,
                OrderID = itemTracker.OrderID,
                ItemStatus = itemTracker.ItemStatus,
                TimeStamp = itemTracker.TimeStamp


            };
        }

        public ITEMTRACKER CreateItemTrackerFromItemTrackerDTO(ItemTrackerDTO itemTrackerDTO)
        {
            return new ITEMTRACKER()
            {
                ItemTrackerID = itemTrackerDTO.ItemTrackerID,
                ItemID = itemTrackerDTO.ItemID,
                OrderID = itemTrackerDTO.OrderID,
                ItemStatus = itemTrackerDTO.ItemStatus,
                TimeStamp = itemTrackerDTO.TimeStamp
            };
        }

       
    }
}
