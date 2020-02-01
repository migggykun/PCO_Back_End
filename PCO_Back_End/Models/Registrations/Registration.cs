using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCO_Back_End.Models.Accounts;
using PCO_Back_End.Models.Conferences;

namespace PCO_Back_End.Models.Registrations
{
    public class Registration
    {
        public int registrationId { get; set; }

        public int accountId { get; set; }
        public Account Account { get; set; }

        public int conferenceId { get; set; }
        public Conference Conference { get; set; }

        public DateTime? registrationDate { get; set; }

        public bool isPaid { get; set; }

        public virtual Payment Payment { get; set; }
    }
}