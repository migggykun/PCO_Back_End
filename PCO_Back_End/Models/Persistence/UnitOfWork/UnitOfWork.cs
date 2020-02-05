using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PCO_Back_End.Models.Entities;
using PCO_Back_End.Models.Accounts;
using PCO_Back_End.Models.Persistence.Repositories;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace PCO_Back_End.Models.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PCO_Context _context;
        public Repository<MembershipType> MembershipTypes { get; set; }
        public Repository<Account> Accounts { get; set; }
        public LoginCredentialRepository LoginCredentials { get; set; }
        public Repository<PRCDetail> PRCDetails { get; set; }

        public UnitOfWork(PCO_Context context) 
        {
            _context = context;
            MembershipTypes = new Repository<MembershipType>(_context);
            Accounts = new Repository<Account>(_context);
            PRCDetails = new Repository<PRCDetail>(_context);
            LoginCredentials = new LoginCredentialRepository(_context);
        }

        /// <summary>
        /// Reflect changes to database
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateException dbu)
            {
                var exception = HandleDbUpdateException(dbu);
                throw exception;
            }
        }

        /// <summary>
        /// Throws which entity the error occured
        /// </summary>
        /// <param name="dbu"></param>
        /// <returns></returns>
        private Exception HandleDbUpdateException(DbUpdateException dbu)
        {
            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

            try
            {
                foreach (var result in dbu.Entries)
                {
                    builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e.ToString());
            }

            string message = builder.ToString();
            return new Exception(message, dbu);
        }

        //Disconnects connection with external resources
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}