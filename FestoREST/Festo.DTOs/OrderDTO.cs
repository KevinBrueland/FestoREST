using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }

        public decimal? OrderPrice { get; set; }

        public int ClientID { get; set; }
    }
}
