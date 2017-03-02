using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quibill.Domain
{
    class SingleTransaction : ITransaction
    {
        int ITransaction.TransactionId { get; }
        float ITransaction.TransactionAmount { get; }
        string ITransaction.TransactionType { get; } // TODO make this an enum?
        DateTime ITransaction.TransactionDate { get; }
    }
}
