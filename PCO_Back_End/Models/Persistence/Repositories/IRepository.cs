using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace PCO_Back_End.Models.Persistence.Repositories
{
    interface IRepository<TEntity> where TEntity : class
    {
        //GET Operation
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //ADD Operation
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //DELETE Operation
        void Remove(TEntity entity);

        //UPDATE Operation
        void Update(TEntity newEntity);
    }
}
