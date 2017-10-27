﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.DTOs
{
    public class OrderTrackerDTO
    {
        public int OrderTrackerID { get; set; }
        public int OrderID { get; set; }

        public int OrderStatus { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
