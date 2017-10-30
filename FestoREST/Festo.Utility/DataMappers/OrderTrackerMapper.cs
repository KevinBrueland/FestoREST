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
    public class OrderTrackerMapper : BaseMapper<ORDERTRACKER, OrderTrackerDTO>, IOrderTrackerMapper
    {
        public OrderTrackerDTO CreateOrderTrackerDTOFromOrderTracker(ORDERTRACKER orderTracker)
        {
            return new OrderTrackerDTO()
            {
                OrderTrackerID = orderTracker.OrderTrackerID,
                OrderID = orderTracker.OrderID,
                OrderStatus = orderTracker.OrderStatus,
                TimeStamp = orderTracker.TimeStamp
            };
        }

        public ORDERTRACKER CreateOrderTrackerFromOrderTrackerDTO(OrderTrackerDTO orderTrackerDTO)
        {
            return new ORDERTRACKER()
            {
                OrderTrackerID = orderTrackerDTO.OrderTrackerID,
                OrderID = orderTrackerDTO.OrderID,
                OrderStatus = orderTrackerDTO.OrderStatus,
                TimeStamp = DateTime.Now.AddHours(1)
            };
        }

       
    }
}
