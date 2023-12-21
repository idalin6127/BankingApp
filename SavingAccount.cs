using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    public class SavingAccount : Account, ITransaction1
    {
        private static readonly double COST_PER_TRANSACTION = 0.05;
        private static readonly double INTEREST_RATE = 0.015;
        //public SavingAccount(int accountNumber) : base(accountNumber) { }
        public SavingAccount(double balance = 0) : base("SV-", balance)
        {
        }

        public new void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
        }

        public void Withdraw(double amount, Person person)
        {
            if (!this.IsUser(person.Name))
                throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);

            if (!person.IsAuthenticated)
                throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);

            if (amount > Balance)
                throw new AccountException(ExceptionEnum.NO_OVERDRAFT);

            base.Deposit(-amount, person);
        }

        public override void PrepareMonthlyReport()
        {
            int numberOfTransactions = transactions.Count();
            double serviceCharge = numberOfTransactions * COST_PER_TRANSACTION;
            double interest = (LowestBalance * INTEREST_RATE) / 12;

            Balance += interest - serviceCharge;
            transactions.Clear();
            LowestBalance = Balance;
        }

//        public override string ToString()
  //      {
    //        return $"Saving Account Number: {Number}, Balance: {Balance}";
      //  }
    }

}
