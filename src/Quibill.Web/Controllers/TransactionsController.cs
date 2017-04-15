using Quibill.Web.Contexts;
using System;
using System.Collections.Generic;
using Quibill.Domain.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Quibill.Domain;

namespace Quibill.Web.Controllers
{
    [Authorize]
    public class TransactionsController : ApiController
    {
        private TransactionsDbContext transactionsContext;

        public TransactionsController()
        {
            transactionsContext = new TransactionsDbContext();
        }


        // GET api/values
        public IEnumerable<ITransaction> Get()
        {
            string userName = User.Identity.GetUserId();

            List<SingleTransaction> allSingleTransactions = transactionsContext.SingleTransactions.ToList();
            List<RecurringTransaction> allRecurringTransactions = transactionsContext.RecurringTransactions.ToList();

            List<ITransaction> allTransactions = new List<ITransaction>();

            allTransactions.AddRange(allRecurringTransactions);
            allTransactions.AddRange(allSingleTransactions);

            return allTransactions;
        }

        // GET api/values/5
        public int Get(int id)
        {
            return id;
        }

        // POST api/values
        public void Post([FromBody]SingleTransaction singleTransaction)
        {
           singleTransaction.BoundUserId = User.Identity.GetUserId();
           transactionsContext.SingleTransactions.Add(singleTransaction);
           transactionsContext.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
