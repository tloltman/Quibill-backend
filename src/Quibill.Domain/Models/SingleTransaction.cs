using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quibill.Domain
{
    class SingleTransaction : ITransaction
    {
        public int TransactionId { get; }
        public float TransactionAmount { get; }
        public string TransactionType { get; } // TODO make this an enum?
        public DateTime AddDate { get; }

        public DateTime TransactionDate { get; }
    }
}
