namespace Festo.DataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ALARM")]
    public partial class ALARM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALARM()
        {
            ALARMTRACKER = new HashSet<ALARMTRACKER>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlarmID { get; set; }

        [Required]
        [StringLength(30)]
        public string AlarmType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALARMTRACKER> ALARMTRACKER { get; set; }
    }
}
