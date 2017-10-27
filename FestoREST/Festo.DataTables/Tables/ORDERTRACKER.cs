namespace Festo.DataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERTRACKER")]
    public partial class ORDERTRACKER
    {
        public int OrderID { get; set; }

        public int OrderStatus { get; set; }

        public DateTime TimeStamp { get; set; }

        public int OrderTrackerID { get; set; }

        public virtual ORDERS ORDERS { get; set; }

        public virtual ORDERSTATUS ORDERSTATUS1 { get; set; }
    }
}
