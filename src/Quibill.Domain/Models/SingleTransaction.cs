using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quibill.Domain.Models
{
    public class SingleTransaction : ITransaction
    {
        [Key]
        public int TransactionId { get; set; }
        public decimal TransactionAmount { get; set; }
        public DTO.Enums.TransactionType TransactionType { get; set; }
        public DateTime AddDate { get; set; }
        public string BoundUserId { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
