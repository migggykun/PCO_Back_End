using PCO_Back_End.Models.Accounts;
using PCO_Back_End.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCO_Back_End.Models.Persistence.Repositories
{
    public class LoginCredentialRepository : Repository<LoginCredential>, ILoginRepository
    {
        public LoginCredentialRepository(PCO_Context context) : base(context)
        {
          
        }


        public LoginCredential GetLoginInfobyEmail(string email)
        {
            var acquiredLoginInfo = pco_Context.LoginCredentials.FirstOrDefault(x => string.Compare(x.email, email, true) == 0);
            if (acquiredLoginInfo != null)
            {
                return acquiredLoginInfo;
            }
            else
            {
                return null;
            }
        }

        public PCO_Context pco_Context
        {
            get
            {
                return _context as PCO_Context;
            }
        }
    }
}