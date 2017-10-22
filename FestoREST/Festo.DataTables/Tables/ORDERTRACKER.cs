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
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderStatusID { get; set; }

        public DateTime? TimeStamp { get; set; }

        public virtual ORDERS ORDERS { get; set; }

        public virtual ORDERSTATUS ORDERSTATUS { get; set; }
    }
}
