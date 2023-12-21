using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    public interface ITransaction1
    {
        string Number { get; }

        void Withdraw(double amount, Person person);
        void Deposit(double amount, Person person);
        void AddUser(Person person); ////
    }
}
