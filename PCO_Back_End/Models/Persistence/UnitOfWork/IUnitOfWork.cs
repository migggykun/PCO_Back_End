using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCO_Back_End.Models.Persistence.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
