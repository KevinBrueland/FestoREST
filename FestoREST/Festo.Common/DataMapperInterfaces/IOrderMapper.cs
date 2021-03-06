﻿using Festo.DataTables.Tables;
using Festo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.DataMapperInterfaces
{
    public interface IOrderMapper : IBaseMapper<ORDERS,OrderDTO>
    {
        OrderDTO CreateOrderDTOFromOrder(ORDERS order);
        ORDERS CreateOrderFromOrderDTO(OrderDTO orderDTO);





    }
}
