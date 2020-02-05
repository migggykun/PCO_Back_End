using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCO_Back_End.Models.Persistence.Repositories;
using PCO_Back_End.Models.Accounts;
namespace PCO_Back_End.Models.Persistence.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        Repository<MembershipType> MembershipTypes { get; set; }
        Repository<Account> Accounts { get; set; }
        Repository<PRCDetail> PRCDetails { get; set; }
        LoginCredentialRepository LoginCredentials { get; set; }
        
        int Complete();
    }
}
