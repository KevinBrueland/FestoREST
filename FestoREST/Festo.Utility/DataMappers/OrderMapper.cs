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
    public class OrderMapper : IOrderMapper
    {
        public OrderDTO CreateOrderDTOFromOrder(ORDERS order)
        {
            return new OrderDTO()
            {
                OrderID = order.OrderID,
                ClientID = order.ClientID,
                OrderPrice = order.OrderPrice
            };
        }

        public ORDERS CreateOrderFromOrderDTO(OrderDTO orderDTO)
        {
            return new ORDERS()
            {
                OrderID = orderDTO.OrderID,
                ClientID = orderDTO.ClientID,
                OrderPrice = orderDTO.OrderPrice
            };
        }

        public object CreateShapeDataObject(ORDERS order, List<string> listOfFields)
        {
            //pass through from entity to DTO
            return CreateShapeDataObject(CreateOrderDTOFromOrder(order), listOfFields);
        }

        public object CreateShapeDataObject(OrderDTO orderDTO, List<string> listOfFields)
        {
            if (!listOfFields.Any())
            {
                return orderDTO;
            }
            else
            {
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in listOfFields)
                {
                    var fieldValue = orderDTO.GetType()
                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(orderDTO, null);

                    ((IDictionary<string, object>)objectToReturn).Add(field, fieldValue);
                }

                return objectToReturn;
            }

        }
    }
}
