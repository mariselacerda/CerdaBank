using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerdaBank
{
    static class Bank
    {
        //private static List<Account> accounts = new List<Account>(); removed all references to this list, switched to db


        private static BankModel db = new BankModel();
        public static Account CreateAccount(string emailAddress, AccountTypes typeOfAccount, decimal amount) 
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException("email address cannot be empty");
            }

            if (amount < 0.0M)
            {
                throw new ArgumentException("amount cannot be less than 0");
            }

            var CheckAccountType = Enum.GetName(typeof(AccountTypes), typeOfAccount);
            if (string.IsNullOrEmpty(CheckAccountType))
            {
                throw new ArgumentException("invalid account type");
                  
            }

            var account = new Account { EmailAddress = emailAddress, AccountType = (AccountTypes)typeOfAccount };
           account.Deposit(amount);
            // accounts.Add(account);

          db.Accounts.Add(account);
            db.SaveChanges(); //committs db changes
           return account; 

        }

        public static List<Account> GetAllAccounts() { 
            return db.Accounts.ToList();
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault(); 
            if (account != null)
            {
                account.Deposit(amount);
                db.SaveChanges();
                CreateTransaction("Deposit", TransactionType.Credit, amount, account.AccountNumber);
            }
            
        }

        public static decimal WithDraw(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if ((account != null) & (account.getBalance() > amount))
            {
                account.withdraw(amount);
                db.SaveChanges();
               CreateTransaction("Withdraw", TransactionType.Debit, amount, account.AccountNumber);
                return amount;
            }
            else
            {
                return 0; 
            } 

        }

        private static void CreateTransaction(string description, TransactionType typeofTransaction, decimal amount, int accountNumber)
        {
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = description,
                TypeOfTransaction = typeofTransaction,
                Amount = amount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges(); 
        }

        public static List<Transaction> GetAllTransactions(int accountNumber)
        {
           return db.Transactions.Where(t => t.AccountNumber == accountNumber).ToList(); 
        }
    }

}
