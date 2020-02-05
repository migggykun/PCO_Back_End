using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PCO_Back_End.Models.Accounts
{
    public partial class Account
    {
        public int accountId { get; set; }

        [Required]
        [StringLength(50)]
        public string firstName { get; set; }

        [Required]
        [StringLength(50)]
        public string middleName { get; set; }

        [Required]
        [StringLength(50)]
        public string lastName { get; set; }

        [Required]
        [StringLength(255)]
        public string address { get; set; }

        [Required]
        [StringLength(11)]
        public string contactNo { get; set; }

        [Required]
        [StringLength(20)]
        public string location { get; set; }

        public DateTime member_Since { get; set; }

        public bool isAdmin { get; set; }

        public int membershipTypeId { get; set; }
        public MembershipType membershipType { get; set; }

        public virtual LoginCredential LoginCredential { get; set; }

        public virtual PRCDetail PRCDetail { get; set; }
    }
}
