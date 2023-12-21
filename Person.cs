using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    public class Person
    {
        private string password;

        public bool IsAuthenticated { get; private set; }
        public string SIN { get; }
        public string Name { get; }
        public ExceptionEnum AccountEnum { get; private set; } ////

        public Person(string name, string sin)
        {
            Name = name;
            SIN = sin;
            password = SIN.Substring(0, 3);
            IsAuthenticated = false;
            AccountEnum = ExceptionEnum.PASSWORD_INCORRECT; //// Initialize AccountEnum here
        }

        public void Login(string passwordAttempt)
        {
            if (passwordAttempt != password)
            {
                IsAuthenticated = false;
                throw new AccountException(AccountEnum);
            }

            IsAuthenticated = true;
        }

        public void Logout()
        {
            IsAuthenticated = false;
        }

        public override string ToString()
        {
            //return Name;
            string authenticationStatus = IsAuthenticated ? "Authenticated" : "Not Authenticated";
            return $"Name: {Name}, Authentication Status: {authenticationStatus}";
        }


    }
}
