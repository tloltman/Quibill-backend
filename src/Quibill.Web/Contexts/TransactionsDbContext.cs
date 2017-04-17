using Quibill.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quibill.Web.Contexts
{
    public class TransactionsDbContext : DbContext
    {
        public TransactionsDbContext() : base("DefaultConnection") { }

        public DbSet<RecurringTransaction> RecurringTransactions { get; set; }
        public DbSet<SingleTransaction> SingleTransactions { get; set; }
       
    }
}