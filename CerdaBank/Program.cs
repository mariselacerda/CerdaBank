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

            Console.WriteLine("***********Welcome to Cerda Bank*************");
            Console.WriteLine("Please select from the following options");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1: Create a new account");
            Console.WriteLine("2: Deposit");
            Console.WriteLine("3. Withdraw");
            var optioninput = Console.ReadLine();
            switch (optioninput)
            {
                case "0":
                    Console.WriteLine("Thank You for Visiting Goodbye");
                    break;
                case "1":
                    var account1 = new Account();
                    Console.Write("Please provide your email address: ");
                    var emailAddress = Console.ReadLine();
                    Console.Write("Please provide the type of account: ");
                    var typeofAccount = Console.ReadLine();

                    account1.EmailAddress = emailAddress;
                    account1.AccountType = typeofAccount;
                    Console.WriteLine($"AccountNumber:{account1.AccountNumber},TypeOfAccount: {account1.AccountType},EmailAddress: {account1.EmailAddress}, Balance: {account1.Balance:C}");
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    break;
            }
           
            
        }

    }
}
