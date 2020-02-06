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
using PCO_Back_End.DTOs;
using AutoMapper;

namespace PCO_Back_End.Controllers.api.Accounts
{
    public class MembershipTypeController : ApiController , ICRUD<MembershipTypeDTO>
    {
        private PCO_Context _context;

        public MembershipTypeController()
        {
            _context = new PCO_Context();
        }

        [HttpPost]
        public IHttpActionResult Add(MembershipTypeDTO userInput)
        {
            var membershipType = Mapper.Map<MembershipTypeDTO, MembershipType>(userInput);
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork(_context);
                unitOfWork.MembershipTypes.Add(membershipType);
                unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork(_context);
                var membershipTypes = unitOfWork.MembershipTypes.GetAll();
                var membershipTypesDTO = membershipTypes.Select(Mapper.Map<MembershipType, MembershipTypeDTO>);
                return Ok(membershipTypesDTO);
            }
            catch (Exception)
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork(_context);
                var membershipType = unitOfWork.MembershipTypes.Get(id);
                var membershipTypeDTO = Mapper.Map<MembershipType, MembershipTypeDTO>(membershipType);
                return Ok(membershipTypeDTO);
            }
            catch (Exception)
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork(_context);
                var membershipType = unitOfWork.MembershipTypes.Get(id);
                unitOfWork.MembershipTypes.Remove(membershipType);
                unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
        }

        [HttpPut]
        public IHttpActionResult Update(MembershipTypeDTO userInput)
        {
            var membershipType = Mapper.Map<MembershipTypeDTO, MembershipType>(userInput);
            UnitOfWork unitOfWork = new UnitOfWork(_context);

            try
            {
                unitOfWork.MembershipTypes.Update(membershipType);
                unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotModified));
            }
        }

        
    }
}
