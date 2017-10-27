using Festo.DataTables.Tables;
using Festo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.DataMapperInterfaces
{
    public interface IItemMapper : IBaseMapper<ITEM, ItemDTO>
    {
        ItemDTO CreateItemDTOFromItem(ITEM itemTracker);
        ITEM CreateItemFromItemDTO(ItemDTO itemTrackerDTO);
    }
}
