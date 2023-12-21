using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    public static class Bank
    {
        public static readonly List<Account> ACCOUNTS;
        internal static readonly List<Person> USERS;

        static Bank()
        {
            USERS = new List<Person>()
        {
            new Person("Janani", "1234-5678"),  // 0
            new Person("Ilia", "2345-6789"),    // 1
            new Person("Tom", "3456-7890"),     // 2
            new Person("Syed", "4567-8901"),    // 3
            new Person("Arben", "5678-9012"),   // 4
            new Person("Patrick", "6789-0123"), // 5
            new Person("Yin", "7890-1234"),     // 6
            new Person("Hao", "8901-2345"),     // 7
            new Person("Jake", "9012-3456"),    // 8
            new Person("Joanne", "1224-5678"),  // 9
            new Person("Nicoletta", "2344-6789"), // 10
        };

            ACCOUNTS = new List<Account>()
        {
            new VisaAccount(),                   // VS-100000
            new VisaAccount(150, -500),          // VS-100001
            new SavingAccount(5000),             // SV-100002     
            new SavingAccount(),                 // SV-100003
            new CheckingAccount(2000),           // CK-100004
            new CheckingAccount(1500, true),     // CK-100005
            new VisaAccount(50, -550),           // VS-100006
            new SavingAccount(1000),             // SV-100007
        };

            // Associate users with accounts
            ACCOUNTS[0].AddUser(USERS[0]);
            ACCOUNTS[0].AddUser(USERS[1]);
            ACCOUNTS[0].AddUser(USERS[2]);
            ACCOUNTS[1].AddUser(USERS[3]);
            ACCOUNTS[1].AddUser(USERS[4]);
            ACCOUNTS[1].AddUser(USERS[5]);
            ACCOUNTS[2].AddUser(USERS[6]);
            ACCOUNTS[2].AddUser(USERS[7]);
            ACCOUNTS[2].AddUser(USERS[8]);
            ACCOUNTS[3].AddUser(USERS[9]);
            ACCOUNTS[3].AddUser(USERS[10]);
            ACCOUNTS[4].AddUser(USERS[2]);
            ACCOUNTS[4].AddUser(USERS[4]);
            ACCOUNTS[4].AddUser(USERS[6]);
            ACCOUNTS[5].AddUser(USERS[8]);
            ACCOUNTS[5].AddUser(USERS[10]);
            ACCOUNTS[6].AddUser(USERS[1]);
            ACCOUNTS[6].AddUser(USERS[3]);
            ACCOUNTS[7].AddUser(USERS[5]);
            ACCOUNTS[7].AddUser(USERS[7]);
        }

        public static void PrintAccounts()
        {
            foreach (var account in ACCOUNTS)
            {
                Console.WriteLine(account.ToString());
                
            }
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        public static void PrintPersons()
        {
            Console.WriteLine("Persons:");
            foreach (var user in USERS)
            {
                Console.WriteLine(user.ToString());
            }
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        public static Person GetPerson(string name)
        {
            foreach (var user in USERS)
            {
                if (user.Name == name)
                {
                    return user;
                }
            }

            throw new AccountException(ExceptionEnum.USER_DOES_NOT_EXIST);
        }

        public static ITransaction1 GetAccount(string number)
        {
            ITransaction1 t = null;
            foreach (Account account in ACCOUNTS)
            {
                //Console.WriteLine($"Checking account: {account.Number}");
                if (account.Number == number)
                {
                    t = (ITransaction1)account;

                }
            }
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new AccountException(ExceptionEnum.ACCOUNT_DOES_NOT_EXIST);
            }

        }

        //public static ITransaction1 GetAccount(string number)
        //{

        //    foreach (Account account in ACCOUNTS)
        //    {
        //        Console.WriteLine($"Checking account: {account.Number}");
        //        if (account.Number == number)
        //        {
        //            return (ITransaction1)account;

        //        }
        //    }

        //        throw new AccountException(ExceptionEnum.ACCOUNT_DOES_NOT_EXIST);

        //}

        //public static Account GetAccount(string number)
        //{
        //    Account t = null;
        //    foreach (Account account in ACCOUNTS)
        //    {
        //        Console.WriteLine($"Checking account: {account.Number}");
        //        if (account.Number == number)
        //        {
        //            return (Account)account;

        //        }
        //    }

        //    throw new AccountException(ExceptionEnum.ACCOUNT_DOES_NOT_EXIST);

        //}

    }

}
