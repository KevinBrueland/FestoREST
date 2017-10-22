namespace Festo.DataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ALARMTRACKER")]
    public partial class ALARMTRACKER
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlarmID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlarmStatusID { get; set; }

        public DateTime? TimeStamp { get; set; }

        public virtual ALARM ALARM { get; set; }

        public virtual ALARMSTATUS ALARMSTATUS { get; set; }
    }
}
