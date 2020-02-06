using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCO_Back_End.DTOs;
using PCO_Back_End.Models.Accounts;
using PCO_Back_End.Models.Entities;
using PCO_Back_End.Models.Persistence.UnitOfWork;
using AutoMapper;

namespace PCO_Back_End.Controllers.api.Accounts
{
    public class UserAccountController : ApiController, ICRUD<AccountsDTO>
    {

        [HttpPost]
        public IHttpActionResult Add(AccountsDTO userInput)
        {
            var account = Mapper.Map<AccountsDTO, Account>(userInput);
            AccountsDB accountsDB = new AccountsDB();
            try
            {
                accountsDB.Add(account);
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
            AccountsDB accountsDB = new AccountsDB();
            try
            {
                var retrievedAccounts = accountsDB.GetAll();
                var accountsDTO = retrievedAccounts.Select(Mapper.Map <Account,AccountsDTO>);
                return Ok(accountsDTO);
            }
            catch(Exception)
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            AccountsDB accountsDB = new AccountsDB();
            try
            {
                var retrievedAccount = accountsDB.Get(id);
                var accountDTO = Mapper.Map<Account, AccountsDTO>(retrievedAccount);
                return Ok(accountDTO);
            }
            catch(Exception)
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            AccountsDB accountsDB = new AccountsDB();
            try
            {
                accountsDB.Remove(id);
                return Ok();
            }
            catch (Exception)
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
        }

        [HttpPut]
        public IHttpActionResult Update(AccountsDTO userInput)
        {
            var account = Mapper.Map<AccountsDTO, Account>(userInput);
            AccountsDB accountsDB = new AccountsDB();
            try
            {
                accountsDB.Update(account);
                return Ok();
            }
            catch (Exception)
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
        }
    }
}
