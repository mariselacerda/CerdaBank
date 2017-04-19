using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerdaBank
{
    public enum AccountTypes { Checking, Savings}
    public class Account
    {
        #region StaticVars
        //private static int LastAccountNumber = 0;

        #endregion
        #region Properties
        /// <summary>
        /// Create account number as a public integer
        /// </summary>
        [Key]
        public int AccountNumber { get; set; } 
        public string EmailAddress { get; set; }
        public decimal Balance { get; set;}
        public AccountTypes AccountType { get; set; }
        //Type of Account
        public virtual ICollection <Transaction> Transactions { get; set; } //creates a relationship between account table and transactions

        #endregion Properties

        #region Constructor
        //public Account()
        //{
        //    AccountNumber = ++LastAccountNumber;
        //}


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

        public decimal getBalance()
        {
            return Balance; 
        }


       #endregion

    }
}
