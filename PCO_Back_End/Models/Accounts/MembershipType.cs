using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PCO_Back_End.Models.Accounts
{
    public partial class MembershipType
    {
        [Key]
        public int membershipTypeId { get; set; }

        [Required]
        [StringLength(30)]
        public string membershipTypeName { get; set; }
    }
}
