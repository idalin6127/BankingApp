using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    public abstract class Account
    {
        public readonly List<Person> users = new List<Person>();
        public readonly List<Transaction> transactions = new List<Transaction>();
        private static int LAST_NUMBER = 100_000;

        public string Number { get; }
        public double Balance { get; protected set; }
        public double LowestBalance { get; protected set; }

        public Account(string type, double balance)
        {
            string accountTypePrefix = GetAccountTypePrefix(type);
            Number = GenerateAccountNumber(accountTypePrefix);
            Balance = balance;
            LowestBalance = balance;
            users = new List<Person>();
            transactions = new List<Transaction>();LAST_NUMBER++;
        }
        private string GenerateAccountNumber(string accountTypePrefix)
        {
            return $"{accountTypePrefix}-{LAST_NUMBER}";
        }

        private string GetAccountTypePrefix(string type)
        {
            switch (type)
            {
                case "VS-":
                    return "VS";
                case "SV-":
                    return "SV";
                case "CK-":
                    return "CK";
                default:
                    throw new ArgumentException("Invalid account type provided");
            }
        }

        public void Deposit(double amount, Person person)
        {
           // Console.WriteLine("deposit called once");
            Balance += amount;
            if (Balance < LowestBalance)
            {
                LowestBalance = Balance;
            }
            Transaction transaction = new Transaction(Number, amount, person, DateTime.Now);
            this.transactions.Add(transaction);
        }

        public void AddUser(Person person)
        {
            users.Add(person);
        }

        public bool IsUser(string name)
        {
            foreach (Person user in users)
            {
                if (user.Name == name)
                    return true;
            }
            return false;
        }


        //public abstract void PrepareMonthlyStatement();

        public override string ToString()
        {
            StringBuilder accountDetails = new StringBuilder();
            accountDetails.AppendLine($"Account Number: {Number}");
            accountDetails.AppendLine("Users:");
            foreach (Person user in users)
            {
                accountDetails.AppendLine($"- {user.Name}");
            }
            accountDetails.AppendLine($"Balance: {Balance}");
            accountDetails.AppendLine("Transactions:");
            foreach (Transaction transaction in transactions)
            {
                accountDetails.AppendLine(transaction.ToString());
            }
            return accountDetails.ToString();
        }

        public abstract void PrepareMonthlyReport();
    }


}
