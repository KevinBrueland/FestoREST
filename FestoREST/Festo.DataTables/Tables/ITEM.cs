namespace Festo.DataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITEM")]
    public partial class ITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ITEM()
        {
            ITEMTRACKER = new HashSet<ITEMTRACKER>();
        }

        [Key]
        [Column(Order = 0)]
        public int ItemID { get; set; }

        public decimal? ItemPrice { get; set; }

        [StringLength(20)]
        public string ItemColour { get; set; }

        public double? ItemWeight { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Required]
        [StringLength(20)]
        public string Size { get; set; }

        public virtual ORDERS ORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEMTRACKER> ITEMTRACKER { get; set; }

        public virtual ITEMSIZE ITEMSIZE { get; set; }
    }
}
