using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCO_Back_End.Models.Entities;
using PCO_Back_End.Models.Accounts;
using PCO_Back_End.Controllers.api;
using PCO_Back_End.Models.Persistence.UnitOfWork;

namespace PCO_Back_End.Controllers.api.Accounts
{
    public class MembershipTypeController : ApiController , ICRUD<MembershipType>
    {
        private PCO_Context _context;

        public MembershipTypeController()
        {
            _context = new PCO_Context();
        }

        [HttpPost]
        public IHttpActionResult Add(MembershipType membershipType)
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            unitOfWork.MembershipTypes.Add(membershipType);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var membershipTypes = unitOfWork.MembershipTypes.GetAll();

            return Ok(membershipTypes);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var accounts = unitOfWork.MembershipTypes.Get(id);
            return Ok(accounts);
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var membershipType = unitOfWork.MembershipTypes.Get(id);
            unitOfWork.MembershipTypes.Remove(membershipType);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(MembershipType newData)
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var oldData = unitOfWork.MembershipTypes.Get(newData.membershipTypeId);
            unitOfWork.MembershipTypes.Update(oldData, newData);
            unitOfWork.Complete();
            return Ok();
        }

        
    }
}
