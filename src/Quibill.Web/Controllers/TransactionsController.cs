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
        public IEnumerable<TransactionsDbContext> Get()
        {
            string userName = User.Identity.GetUserId();

            List<SingleTransaction> allSingleTransactions = transactionsContext.SingleTransactions.ToList();
            List<RecurringTransaction> allRecurringTransactions = transactionsContext.RecurringTransactions.ToList();

            List<TransactionsDbContext> allTransactions = null;

            allTransactions.AddRange(transactionsContext.RecurringTransactions.SqlQuery(userName).ToList());
            allTransactions.AddRange(transactionsContext.SingleTransactions.SqlQuery(userName).ToList());

            return allTransactions;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]int amount)
        {
            SingleTransaction singleTransaction = new SingleTransaction();
            singleTransaction.BoundUserId = "Baruch@test1.com";
            singleTransaction.TransactionAmount = amount;
            singleTransaction.TransactionDate = DateTime.Now;
            singleTransaction.TransactionType = DTO.Enums.TransactionType.Deposit;

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
