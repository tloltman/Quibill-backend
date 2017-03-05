using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quibill.Domain.Models
{
    class RecurringTransaction : ITransaction
    {
        public int TransactionId { get; }
        public float TransactionAmount { get; }
        public string TransactionType { get; }
        public DateTime AddDate { get; }

        public int TransactionRecurrenceDay { get; }


        //Validates that the user doesn't select a transaction date outside the range of the month.
        private int ValidateTransactionDateSelection(int TransactionDateSelection)
        {
            DateTime currentDateTime = DateTime.Now;
            int currentDaysInMonth = DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month);

            if (TransactionDateSelection > 0 && TransactionDateSelection <= currentDaysInMonth)
            {
                return TransactionDateSelection;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Please choose a valid day of the month"); //TODO handle this and remove exception.
            }
        }
       

       

        

       
    }
}
