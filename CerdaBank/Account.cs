using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerdaBank
{
    class Account
    {
        #region Properties
        /// <summary>
        /// Create account number as a public integer
        /// </summary>
        public int AccountNumber { get;} 
        public string EmailAddress { get; set; }
        public decimal Balance { get; private set;}
        public string AccountType { get; set; } 
        //Type of Account
        #endregion Properties

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
