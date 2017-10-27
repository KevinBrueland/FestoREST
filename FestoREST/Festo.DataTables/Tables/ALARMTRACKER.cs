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
        public int AlarmID { get; set; }

        public int AlarmStatus { get; set; }

        public DateTime? TimeStamp { get; /*set;*/ }

        public int AlarmTrackerID { get; set; }

        public virtual ALARM ALARM { get; set; }

        public virtual ALARMSTATUS ALARMSTATUS1 { get; set; }
    }
}
