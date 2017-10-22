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
    public class ItemTrackerMapper
    {
        public ItemTrackerDTO CreateItemTrackerDTOFromItemTracker(ITEMTRACKER itemTracker)
        {
            return new ItemTrackerDTO()
            {
                OrderID = itemTracker.OrderID,
                ItemID = itemTracker.ItemID,
                ItemStatusID = itemTracker.ItemStatusID,
                TimeStamp = itemTracker.TimeStamp

            };
        }

        public ITEMTRACKER CreateItemTrackerFromItemTrackerDTO(ItemTrackerDTO itemTrackerDTO)
        {
            return new ITEMTRACKER()
            {
                OrderID = itemTrackerDTO.OrderID,
                ItemID = itemTrackerDTO.ItemID,
                ItemStatusID = itemTrackerDTO.ItemStatusID,
                TimeStamp = itemTrackerDTO.TimeStamp
            };
        }

        public object CreateShapeDataObject(ITEMTRACKER itemTracker, List<string> listOfFields)
        {
            //pass through from entity to DTO
            return CreateShapeDataObject(itemTracker, listOfFields);
        }

        public object CreateShapeDataObject(ItemTrackerDTO itemTrackerDTO, List<string> listOfFields)
        {
            if (!listOfFields.Any())
            {
                return itemTrackerDTO;
            }
            else
            {
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in listOfFields)
                {
                    var fieldValue = itemTrackerDTO.GetType()
                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(itemTrackerDTO, null);

                    ((IDictionary<string, object>)objectToReturn).Add(field, fieldValue);
                }

                return objectToReturn;
            }
        }
    }
}
