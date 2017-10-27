namespace Festo.DataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITEMTRACKER")]
    public partial class ITEMTRACKER
    {
        public int ItemStatus { get; set; }

        public int ItemID { get; set; }

        public int OrderID { get; set; }

        public DateTime TimeStamp { get; set; }

        public int ItemTrackerID { get; set; }

        public virtual ITEM ITEM { get; set; }

        public virtual ITEMSTATUS ITEMSTATUS1 { get; set; }
    }
}
