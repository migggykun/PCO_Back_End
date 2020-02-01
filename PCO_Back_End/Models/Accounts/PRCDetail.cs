using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PCO_Back_End.Models.Accounts
{
    public partial class PRCDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int prcId { get; set; }

        [Required]
        [StringLength(20)]
        public string prcNo { get; set; }

        public DateTime prcExpirationDate { get; set; }

        public virtual Account Account { get; set; }
    }
}
