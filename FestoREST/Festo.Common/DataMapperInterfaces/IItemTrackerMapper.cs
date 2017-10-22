using Festo.DataTables.Tables;
using Festo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.DataMapperInterfaces
{
    public interface IItemTrackerMapper
    {
        ItemTrackerDTO CreateItemTrackerDTOFromItemTracker(ITEMTRACKER itemTracker);
        ITEMTRACKER CreateItemTrackerFromItemTrackerDTO(ItemTrackerDTO itemTrackerDTO);

        object CreateShapeDataObject(ITEMTRACKER itemTracker, List<string> listOfFields);

        object CreateShapeDataObject(ItemTrackerDTO itemTrackerDTO, List<string> listOfFields);
    }
}
