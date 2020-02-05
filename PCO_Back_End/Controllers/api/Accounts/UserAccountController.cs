using PCO_Back_End.Models.Accounts;
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
    public class UserAccountController : ApiController, ICRUD<Account>
    {

        [HttpPost]
        public IHttpActionResult Add(Account account)
        {
            AccountsDB accountsDB = new AccountsDB();
            accountsDB.Add(account);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            AccountsDB accountsDB = new AccountsDB();
            var retrievedAccounts = accountsDB.GetAll();

            return Ok(retrievedAccounts);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            AccountsDB accountsDB = new AccountsDB();
            var retrievedAccount = accountsDB.Get(id);

            return Ok(retrievedAccount);
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            AccountsDB accountsDB = new AccountsDB();
            accountsDB.Get(id);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Account newData)
        {
            AccountsDB accountsDB = new AccountsDB();
            accountsDB.Update(newData);

            return Ok();
        }
    }
}
