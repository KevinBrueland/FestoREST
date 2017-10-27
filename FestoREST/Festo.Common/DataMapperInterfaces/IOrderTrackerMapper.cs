using Festo.DataTables.Tables;
using Festo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.DataMapperInterfaces
{
    public interface IOrderTrackerMapper : IBaseMapper<ORDERTRACKER, OrderTrackerDTO>
    {
        OrderTrackerDTO CreateOrderTrackerDTOFromOrderTracker(ORDERTRACKER orderTracker);
        ORDERTRACKER CreateOrderTrackerFromOrderTrackerDTO(OrderTrackerDTO orderTrackerDTO);

    }
}
