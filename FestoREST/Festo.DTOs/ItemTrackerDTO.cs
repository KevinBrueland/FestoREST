using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.DTOs
{
    public class ItemTrackerDTO
    {
        public int ItemStatusID { get; set; }

        public int ItemID { get; set; }

        public int OrderID { get; set; }

        public DateTime? TimeStamp { get; set; }
    }
}
