using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.DTOs
{
    public class ItemDTO
    {
        public int ItemID { get; set; }

        public decimal? ItemPrice { get; set; }

        public string ItemColour { get; set; }

        public double? ItemWeight { get; set; }

        public int OrderID { get; set; }

        public string Size { get; set; }
    }
}
