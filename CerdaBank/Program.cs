using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerdaBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account1 = new Account();
            account1.EmailAddress = "test@test.com";
            account1.AccountType = "Checking";
            account1.Deposit(100.01M);
            Console.WriteLine($"AccountNumber:{account1.AccountNumber},TypeOfAccount: {account1.AccountType},EmailAddress: {account1.EmailAddress}, Balance: {account1.Balance:C}");
        }

    }
}
