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

            while (true)
            {
                Console.WriteLine("Please select from the following options");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1: Create a new account");
                Console.WriteLine("2: Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all accounts");
                Console.WriteLine("5. Print all transactions");
                var optioninput = Console.ReadLine();
                switch (optioninput)
                {
                    case "0":
                        Console.WriteLine("Thank You for Visiting Goodbye");
                        return;
                    case "1":
                        //var account1 = new Account();
                        Console.WriteLine("Please provide your email address: ");
                        var emailAddress = Console.ReadLine();
                        Console.WriteLine("Please provide the type of account: ");
                        var accountTypes = Enum.GetNames(typeof(AccountTypes));
                        for (var i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {accountTypes[i]}");
                        }
                        try
                        {
                            var typeofAccount = Convert.ToInt32(Console.ReadLine());

                            var account1 = Bank.CreateAccount(emailAddress, (AccountTypes)(typeofAccount - 1), 0.0M);

                            //var account1 = new Account { EmailAddress = emailAddress, AccountType = typeofAccount };
                            Console.WriteLine($"AccountNumber:{account1.AccountNumber},TypeOfAccount: {account1.AccountType},EmailAddress: {account1.EmailAddress}, Balance: {account1.Balance:C}");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please select an account number from the account type list.");
                        }
                        catch (OverflowException)
                        {

                        }
                        catch (ArgumentNullException ane)
                        {
                            Console.WriteLine($"Account Creation Failed: {ane.Message}");
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine($"Account Creation Faile: {ae.Message}");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid Selection Returning to Main Menu");
                        }
                            break;
                    case "2":
                        PrintAllAccounts();
                        Console.WriteLine("Pick an account number to deposit: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to Deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, amount);
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.WriteLine("Pick an account number to withdraw from: ");
                        var accountNumber2 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to Withdraw: ");
                        var amount2 = Convert.ToDecimal(Console.ReadLine());
                        var withdrawresult = Bank.WithDraw(accountNumber2, amount2);
                        Console.WriteLine($"You withdrew ${withdrawresult}");
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.WriteLine("Pick an account number to withdraw from: ");
                        var accountNumber3 = Convert.ToInt32(Console.ReadLine());
                        PrintAllTransactions(accountNumber3);
                        break;
                    default:
                        Console.WriteLine("Invalid Option: Please Try Again");
                        break;
                }
            }


        }

        private static void PrintAllAccounts()
        {
            var accounts = Bank.GetAllAccounts();
            foreach (var account in accounts)
            {
                Console.WriteLine($"AccountNumber:{account.AccountNumber},TypeOfAccount: {account.AccountType},EmailAddress: {account.EmailAddress}, Balance: {account.Balance:C}");
            }
        }

        private static void PrintAllTransactions(int accountNumber)
        {
            var transactions = Bank.GetAllTransactions(accountNumber);
            foreach (var tran in transactions)
            {
                Console.WriteLine($"TransactionID:{tran.TransactionID},TypeOfTransaction: {tran.TypeOfTransaction},TransactionDate {tran.TransactionDate} TransactionDescription: {tran.Description} TransactionAmount: {tran.Amount}");
            }
        }
    }
}
