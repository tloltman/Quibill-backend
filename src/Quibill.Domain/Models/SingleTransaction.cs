using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quibill.Domain.Models
{
    public class SingleTransaction : ITransaction
    {
        public int TransactionId { get; set; }
        public decimal TransactionAmount { get; set; }
        public DTO.Enums.TransactionType TransactionType { get; set; }
        public DateTime AddDate { get; set; }
        public string BoundUser { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
