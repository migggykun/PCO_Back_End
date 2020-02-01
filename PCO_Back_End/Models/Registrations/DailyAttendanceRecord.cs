using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PCO_Back_End.Models.Registrations
{
    public partial class DailyAttendanceRecord
    {
        [Key]
        public int dailyAttendanceId { get; set; }

        public int registrationId { get; set; }
        public Registration Registration { get; set; }

        public DateTime attendanceDate { get; set; }

        public int periodId { get; set; }
        public Period Period { get; set; }
    }
}
