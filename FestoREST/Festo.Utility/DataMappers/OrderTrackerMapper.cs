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
    public class OrderTrackerMapper
    {
        public OrderTrackerDTO CreateOrderTrackerDTOFromOrderTracker(ORDERTRACKER orderTracker)
        {
            return new OrderTrackerDTO()
            {
                OrderID = orderTracker.OrderID,
                OrderStatusID = orderTracker.OrderStatusID,
                TimeStamp = orderTracker.TimeStamp
            };
        }

        public ORDERTRACKER CreateOrderTrackerFromOrderTrackerDTO(OrderTrackerDTO orderTrackerDTO)
        {
            return new ORDERTRACKER()
            {
                OrderID = orderTrackerDTO.OrderID,
                OrderStatusID = orderTrackerDTO.OrderStatusID,
                TimeStamp = orderTrackerDTO.TimeStamp
            };
        }

        public object CreateShapeDataObject(ORDERTRACKER orderTracker, List<string> listOfFields)
        {
            //pass through from entity to DTO
            return CreateShapeDataObject(orderTracker, listOfFields);
        }

        public object CreateShapeDataObject(OrderTrackerDTO orderTrackerDTO, List<string> listOfFields)
        {
            if (!listOfFields.Any())
            {
                return orderTrackerDTO;
            }
            else
            {
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in listOfFields)
                {
                    var fieldValue = orderTrackerDTO.GetType()
                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(orderTrackerDTO, null);

                    ((IDictionary<string, object>)objectToReturn).Add(field, fieldValue);
                }

                return objectToReturn;
            }

        }
    }
}
