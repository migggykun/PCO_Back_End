using PCO_Back_End.Models.Entities;
using PCO_Back_End.Models.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PCO_Back_End.Controllers.api.Accounts
{
    public class PRCDetailsController : ApiController
    {
        private readonly PCO_Context _context;

        public PRCDetailsController()
        {
            _context = new PCO_Context();
        }

        [HttpGet]
        public IHttpActionResult GetPRCDetail(int id)
        {
            UnitOfWork unitOfwork = new UnitOfWork(_context);
            var PRCDetail = unitOfwork.PRCDetails.Get(id);
            return Ok(PRCDetail);
        }
    }
}
