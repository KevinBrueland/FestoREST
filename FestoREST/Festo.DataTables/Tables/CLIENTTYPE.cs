namespace Festo.DataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLIENTTYPE")]
    public partial class CLIENTTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTTYPE()
        {
            CLIENT = new HashSet<CLIENT>();
        }

        [Key]
        [Column("ClientType")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientType1 { get; set; }

        [StringLength(30)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENT> CLIENT { get; set; }
    }
}
