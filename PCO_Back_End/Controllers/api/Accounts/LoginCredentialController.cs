using AutoMapper;
using PCO_Back_End.DTOs;
using PCO_Back_End.Models.Accounts;
using PCO_Back_End.Models.Accounts.SaltHash;
using PCO_Back_End.Models.Entities;
using PCO_Back_End.Models.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PCO_Back_End.Controllers.api.Accounts
{
    public class LoginCredentialController : ApiController
    {

        private PCO_Context _context;

        public LoginCredentialController()
        {
            _context = new PCO_Context();
        }
        
        [HttpGet]
        public IHttpActionResult CheckIfEmailExists(string email)
        {
            bool result;
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var loginInfo = unitOfWork.LoginCredentials.GetLoginInfobyEmail(email);
            if (loginInfo != null)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return Ok(result);
        }

        [HttpPut]
        public IHttpActionResult UpdatePassword(LoginCredentialDTO InputLoginInfo)
        {
            var userInput = Mapper.Map<LoginCredentialDTO, LoginCredential>(InputLoginInfo);

            //Encrypt Password
            userInput.EncryptPassword();

            //Store in DB
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            unitOfWork.LoginCredentials.Update(userInput);
            unitOfWork.Complete();
            return Ok();
            
        }

        [HttpPost]
        public IHttpActionResult ValidateLogin(LoginCredentialDTO InputLoginInfo)
        {
            var userInput = Mapper.Map<LoginCredentialDTO, LoginCredential>(InputLoginInfo);
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var loginInfo = unitOfWork.LoginCredentials.GetLoginInfobyEmail(userInput.email);
            if (loginInfo != null)
            {
                //Validate Password
                DataCryptography dataCryptography = new DataCryptography();
                string hashedInputPassword = dataCryptography.GetSha256Hash(userInput.passwordHashed, loginInfo.salt);
                if (string.Compare(hashedInputPassword, loginInfo.passwordHashed, false) == 0)
                {
                    return Ok(loginInfo.Account);
                }
                else
                {
                    return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotFound));
                }
            }
            else
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }
    }
}
