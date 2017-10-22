using Festo.DataTables.Tables;
using Festo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.DataMapperInterfaces
{
    public interface IOrderTrackerMapper
    {
        OrderTrackerDTO CreateOrderTrackerDTOFromOrderTracker(ORDERTRACKER orderTracker);
        ORDERTRACKER CreateOrderTrackerFromOrderTrackerDTO(OrderTrackerDTO orderTrackerDTO);

        object CreateShapeDataObject(ORDERTRACKER orderTracker, List<string> listOfFields);

        object CreateShapeDataObject(OrderTrackerDTO orderTrackerDTO, List<string> listOfFields);
    }
}
