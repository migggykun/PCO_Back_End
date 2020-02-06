using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCO_Back_End.Models.Accounts;
using AutoMapper;
using PCO_Back_End.Models.Entities;
using PCO_Back_End.Models.Persistence.UnitOfWork;
using PCO_Back_End.DTOs;

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
            if (PRCDetail == null)
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return Ok(Mapper.Map<PRCDetail, PRCDetailsDTO>(PRCDetail));
        }

        [HttpPut]
        public IHttpActionResult UpdatePRCDetail(PRCDetailsDTO userInput)
        {
            var PRCDetails = Mapper.Map<PRCDetailsDTO, PRCDetail>(userInput);
            UnitOfWork unitOfWork = new UnitOfWork(_context);

            try
            {
                unitOfWork.PRCDetails.Update(PRCDetails);
                return Ok();
            }
            catch (Exception)
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }
    }
}
