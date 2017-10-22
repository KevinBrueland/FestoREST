using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.DTOs
{
    public class OrderTrackerDTO
    {
        public int OrderID { get; set; }

        public int OrderStatusID { get; set; }

        public DateTime? TimeStamp { get; set; }
    }
}
