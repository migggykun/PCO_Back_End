using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCO_Back_End.DTOs
{
    public class AccountsDTO
    {
        public int accountId { get; set; }

        public string firstName { get; set; }

        public string middleName { get; set; }

        public string lastName { get; set; }

        public string address { get; set; }

        public string contactNo { get; set; }

        public string location { get; set; }

        public DateTime member_Since { get; set; }

        public bool isAdmin { get; set; }

        public int membershipTypeId { get; set; }
    }
}