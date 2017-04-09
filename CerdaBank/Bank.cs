using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerdaBank
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        public static Account CreateAccount(string emailAddress, AccountTypes typeOfAccount, decimal amount) 
        {
           var account = new Account { EmailAddress = emailAddress, AccountType = typeOfAccount };
           account.Deposit(amount);
           accounts.Add(account);
           return account; 

        }

        public static List<Account> GetAllAccounts() { 
            return accounts;
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault(); 
            if (account != null)
            {
                account.Deposit(amount);
            }
        }

        public static decimal WithDraw(int accountNumber, decimal amount)
        {
            var account = accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if ((account != null) & (account.getBalance() > amount))
            {
                account.withdraw(amount);
                return amount;
            }
            else
            {
                return 0; 
            } 

        }
    }
}
