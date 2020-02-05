using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PCO_Back_End.Controllers.api
{
    interface ICRUD<TEntity> where TEntity : class
    {
        IHttpActionResult Add(TEntity jsonParams);

        IHttpActionResult GetAll();
        IHttpActionResult Get (int id);

        IHttpActionResult Remove(int id);
        
        IHttpActionResult Update(TEntity jsonParams);
    }
}
