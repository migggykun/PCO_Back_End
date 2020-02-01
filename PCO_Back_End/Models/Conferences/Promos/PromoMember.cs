using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using PCO_Back_End.Models.Accounts;

namespace PCO_Back_End.Models.Conferences.Promos
{
    public partial class PromoMember
    {
        public int promoMemberId { get; set; }

        public int membershipTypeId { get; set; }

        public int promoId { get; set; }

        public  MembershipType MembershipType { get; set; }

        public  Promo Promo { get; set; }
    }
}
