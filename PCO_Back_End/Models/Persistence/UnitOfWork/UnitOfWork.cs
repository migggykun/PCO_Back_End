using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PCO_Back_End.Models.Entities;

namespace PCO_Back_End.Models.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PCO_Context _context;

        public UnitOfWork(PCO_Context context) 
        {
            _context = context;
        }

        /// <summary>
        /// Reflect changes to database
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        //Disconnects connection with external resources
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}