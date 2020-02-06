using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCO_Back_End.DTOs
{
    public class PRCDetailsDTO
    {
        public int prcId { get; set; }

        public string prcNo { get; set; }

        public DateTime prcExpirationDate { get; set; }
    }
}