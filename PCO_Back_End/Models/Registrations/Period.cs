using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PCO_Back_End.Models.Registrations
{
    public partial class Period
    {

        public int periodId { get; set; }

        [Required]
        [StringLength(2)]
        public string periodName { get; set; }
    }
}
