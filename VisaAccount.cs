using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    public class VisaAccount : Account, ITransaction1
    {
        private static readonly double INTEREST_RATE = 0.1995;
        private double creditLimit;
        //public VisaAccount(int accountNumber) : base(accountNumber) { }

        public VisaAccount(double balance = 0, double creditLimit = 1200) : base("VS-", balance)
        {
            this.creditLimit = creditLimit;
        }

        public void DoPayment(double amount, Person person)
        {
            base.Deposit(amount, person);
        }

        public void DoPurchase(double amount, Person person)
        {
            if (!IsUser(person.Name))
                throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);

            if (!person.IsAuthenticated)
                throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);

            if (Balance - amount < -creditLimit)
                throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);

            base.Deposit(-amount, person);
        }

        public override void PrepareMonthlyReport()
        {
            double interest = (LowestBalance * INTEREST_RATE) / 12;
            Balance -= interest;
            transactions.Clear();
        }

//        public override string ToString()
  //      {
    //        return $"Visa Account Number: {Number}, Balance: {Balance}, Credit Limit: {creditLimit}";
      //  }

        public void Withdraw(double amount, Person person)
        {
          throw new NotImplementedException();
        }
    }

}
