﻿using Festo.Common.DataMapperInterfaces;
using Festo.DataTables.Tables;
using Festo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Utility.DataMappers
{
    class ItemMapper : BaseMapper<ITEM, ItemDTO>, IItemMapper
    {
        public ItemDTO CreateItemDTOFromItem(ITEM item)
        {
            return new ItemDTO()
            {
                ItemID = item.ItemID,
                OrderID = item.OrderID,
                ItemPrice = item.ItemPrice,
                ItemColour = item.ItemColour,
                Size = item.Size,
                ItemWeight = item.ItemWeight,
                MeasuredWeight = item.MeasuredWeight,
                MeasuredDeviation = item.MeasuredDeviation


            };
        }

        public ITEM CreateItemFromItemDTO(ItemDTO itemDTO)
        {
            return new ITEM()
            {
                ItemID = itemDTO.ItemID,
                OrderID = itemDTO.OrderID,
                ItemPrice = itemDTO.ItemPrice,
                ItemColour = itemDTO.ItemColour,
                Size = itemDTO.Size,
                ItemWeight = itemDTO.ItemWeight,
                MeasuredWeight = itemDTO.MeasuredWeight,
                MeasuredDeviation = itemDTO.MeasuredDeviation
            };
        }
    }
}
