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
    public class OrderMapper : BaseMapper<ORDERS,OrderDTO>, IOrderMapper
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

        
    }
}
