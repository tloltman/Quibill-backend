using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quibill.Domain.Models
{
    public class RecurringTransaction : ITransaction
    {
        public int TransactionId { get; }
        public decimal TransactionAmount { get; }
        public DTO.Enums.TransactionType TransactionType { get; }
        public DateTime AddDate { get; }

        public int TransactionRecurrenceDay { get; }


        //Handles the scenario of a user choosing a recurrence date beyond the number of days in the month.
        //Also handles the scenario when the transaction falls on a day that doesn't exist in upcoming months.
        private int HandleOutOfRangeDateSelection(int TransactionRecurrenceDay)
        {
            DateTime currentDateTime = DateTime.Now;
            int currentDaysInMonth = DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month);

            if (TransactionRecurrenceDay > 0 && TransactionRecurrenceDay <= currentDaysInMonth)
            {
                return TransactionRecurrenceDay;
            }
            else if (TransactionRecurrenceDay > currentDaysInMonth)
            {
                return currentDaysInMonth;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Please choose a valid day of the month"); //TODO handle this and remove exception.
            }
        }
       

       

        

       
    }
}
