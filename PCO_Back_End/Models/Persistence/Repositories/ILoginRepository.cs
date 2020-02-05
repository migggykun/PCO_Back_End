using PCO_Back_End.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCO_Back_End.Models.Persistence.Repositories
{
    interface ILoginRepository : IRepository<LoginCredential>
    {
        LoginCredential GetLoginInfobyEmail(string email);


    }
}
