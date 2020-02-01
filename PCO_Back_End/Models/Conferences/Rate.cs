using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using PCO_Back_End.Models.Accounts;

namespace PCO_Back_End.Models.Conferences
{
    public partial class Rate
    {
        [Key]
        public int ratesId { get; set; }

        public int conferenceId { get; set; }
        public Conference Conference { get; set; }

        public int membershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

        public int discountPrice { get; set; }

        
    }
}
