using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerdaBank
{
    enum AccountTypes { Checking, Savings}
    class Account
    {
        #region StaticVars
        private static int LastAccountNumber = 0;

        #endregion
        #region Properties
        /// <summary>
        /// Create account number as a public integer
        /// </summary>
        public int AccountNumber { get; private set; } 
        public string EmailAddress { get; set; }
        public decimal Balance { get; private set;}
        public AccountTypes AccountType { get; set; }
        //Type of Account
        #endregion Properties

        #region Constructor
        public Account()
        {
            AccountNumber = ++LastAccountNumber;
        }
        
        
       //public Account(string typeOfAccount) : this() // will first call a constructor that calls the constructor with empty params
       // {
       //     AccountType = typeOfAccount; 
       // }

       // public Account(string emailAddress, string typeOfAccount): this(typeOfAccount)
       // {
       //     EmailAddress = emailAddress; 
       // }
        
        
        #endregion


        #region Methods
        public void Deposit(decimal amount)
        {
            //Balance = Balance + amount
            Balance += amount;
        }

        public void withdraw(decimal amount)
        {
            Balance -= amount;
        }

       #endregion

    }
}
