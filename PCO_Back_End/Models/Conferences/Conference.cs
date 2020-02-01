using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using PCO_Back_End.Models.Conferences.Promos;

namespace PCO_Back_End.Models.Conferences
{
    public partial class Conference
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Conference()
        {
            Rates = new HashSet<Rate>();
        }

        public int conferenceId { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        [StringLength(255)]
        public string description { get; set; }

        public int attendance_limit { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public virtual Promo Promo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate> Rates { get; set; }
    }
}
