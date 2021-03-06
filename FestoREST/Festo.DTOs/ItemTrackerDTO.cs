﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.DTOs
{
    public class ItemTrackerDTO
    {
        public int ItemTrackerID { get; set; }

        public int ItemStatus { get; set; }

        public int ItemID { get; set; }

        public int OrderID { get; set; }

        public DateTime TimeStamp { get; set; }

        public double? MeasuredWeight { get; set; }
    }
}
