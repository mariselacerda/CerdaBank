using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerdaBank
{
    static class Bank
    {
        public static Account CreateAccount(string emailAddress, AccountTypes typeOfAccount, decimal amount) 
        {
           var account = new Account { EmailAddress = emailAddress, AccountType = typeOfAccount };
           account.Deposit(amount);
           return account; 

        }
     }
}
