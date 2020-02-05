using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCO_Back_End.Models.Accounts.SaltHash;
using PCO_Back_End.Models.Entities;
using PCO_Back_End.Models.Persistence.UnitOfWork;
namespace PCO_Back_End.Models.Accounts
{
    public class AccountsDB
    {
        private PCO_Context _context;

        public AccountsDB()
        {
            _context = new PCO_Context();
        }
        public void Add(Account entity)
        {
            //Encrypt Password
            DataCryptography dataCryptography = new DataCryptography();
            string salt = dataCryptography.CreateSalt();
            string hashedPassword = dataCryptography.GetSha256Hash(entity.LoginCredential.passwordHashed, salt);
            entity.LoginCredential.salt = salt;
            entity.LoginCredential.passwordHashed = hashedPassword;

            //Store Data to DB
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            unitOfWork.Accounts.Add(entity);
            unitOfWork.Complete();
        }

        public IEnumerable<Account> GetAll()
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var accounts = unitOfWork.Accounts.GetAll();

            return accounts;
        }

        public Account Get(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var account = unitOfWork.Accounts.Get(id);
            account.membershipType = unitOfWork.MembershipTypes.Get(account.membershipTypeId);

            return account;
        }

        public void Remove(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var account = unitOfWork.Accounts.Get(id);
            unitOfWork.Accounts.Remove(account);
            unitOfWork.Complete();
        }

        public void Update(Account newData)
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var oldData = unitOfWork.Accounts.Get(newData.accountId);
            unitOfWork.Accounts.Update(oldData, newData);
            unitOfWork.Complete();
        }
    }
}