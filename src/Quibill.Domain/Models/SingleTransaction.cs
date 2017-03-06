using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quibill.Domain
{
    public class SingleTransaction : ITransaction
    {
        public int TransactionId { get; }
        public decimal TransactionAmount { get; }
        public DTO.Enums.TransactionType TransactionType { get; }
        public DateTime AddDate { get; }

        public DateTime TransactionDate { get; }
    }
}
