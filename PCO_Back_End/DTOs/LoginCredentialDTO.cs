using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCO_Back_End.DTOs
{
    public class LoginCredentialDTO
    {
        public int login_accountId { get; set; }

        public string email { get; set; }

        public string passwordHashed { get; set; }
    }
}