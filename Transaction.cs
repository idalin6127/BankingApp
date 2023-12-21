using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    public class Transaction
    {
        public string AccountNumber { get; }
        public double Amount { get; }
        public Person Originator { get; }
        public DateTime Time { get; }

        public Transaction(string accountNumber, double amount, Person person, DateTime time)
        {
            this.AccountNumber = accountNumber;
            this.Amount = amount;
            Originator = person;
            this.Time = time;
        }


        public override string ToString()
        {
            string transactionType = Amount > 0 ? "Deposit" : "Withdraw";
            string transactionInfo = $"{transactionType} - Account Number: {AccountNumber}, " +
                                     $"Person: {Originator.Name}, Amount: {Math.Abs(Amount)}, " +
                                     $"Time: {Time.ToShortTimeString()}";

            return transactionInfo;
        }
    }
}
