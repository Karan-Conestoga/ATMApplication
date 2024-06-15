using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication
{
    internal class AtmApplication
    {
        private string accountHolderName;
        double interestRate;
        double initialBalance;
        private Bank bank;
        int accountNumber;

        //constructor of ATMApplication
        public AtmApplication()
        {
            bank = new Bank();
        }

        public void Run()
        {
            string running = "y";
            while (running == "y")
            {

                //taking the input from the user
                Console.WriteLine("======= Welcome to the ATM Application =======");
                Console.WriteLine("ATM Main Menu:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Select Account");
                Console.WriteLine("3. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        SelectAccount();
                        break;
                    case "3":
                       running= "n";

                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
        //Create Account function definition
        private void CreateAccount()
        {
            Console.WriteLine("======= Welcome to Create Account Menu =======");
            
            Console.Write("Enter account holder name: ");
            accountHolderName = Console.ReadLine();


            // Get and validating account number from user
            Console.Write("Enter the Account No. between 100 and 1000 ");
            accountNumber = int.Parse(Console.ReadLine());
            while (accountNumber > 1000 || accountNumber < 100)
            {
                Console.Write("Invalid Input\n");
                Console.Write("Enter acc No. (between 100 and 1000): ");
                accountNumber = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter Annual Interest Rate less than 3.0%): ");
            interestRate = double.Parse(Console.ReadLine());
            while (interestRate >= 3 || interestRate <= 0 )
            {
                Console.Write("Invalid Input\n");
                Console.Write("Please enter yearly Interest Rate (Has to be less than 3.0%): ");
                interestRate = double.Parse(Console.ReadLine());
            }

            Console.Write("Enter initial balance: ");
            initialBalance = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accountNumber, initialBalance, interestRate, accountHolderName);
            bank.AddAccount(newAccount);
            Console.WriteLine("Account created successfully.");
        }
        //Select Account function definition
        private void SelectAccount()
        {
            Console.Write("Kindly enter acc Numberbetween 100 and 1000");
            accountNumber = int.Parse(Console.ReadLine());
            while (accountNumber > 1000 || accountNumber < 100 )
            {
                Console.Write("Invalid Input\n");
                Console.Write("Kindly enter acc Numberbetween 100 and 1000 ");
                accountNumber = int.Parse(Console.ReadLine());
            }

            Account account = bank.RetrieveAccount(accountNumber);
            if (account != null)
            {
                Console.WriteLine($"Welcome {account.AccountHolderName}");
                Console.WriteLine("Choose the Following Options");
                bool inAccountMenu = true;
                while (inAccountMenu)
                {

                    // Display account menu
                    Console.WriteLine("Account Menu:");
                    Console.WriteLine("a. Check Balance");
                    Console.WriteLine("b. Deposit");
                    Console.WriteLine("c. Withdraw");
                    Console.WriteLine("d. Display Transactions");
                    Console.WriteLine("e. Exit Account");


                    //switch statement as per the user selected option
                    switch (Console.ReadLine())
                    {
                        case "a":
                            Console.WriteLine($"Balance: ${account.Balance}");
                            break;
                        case "b":
                            Console.Write("Enter amount to deposit: ");
                            double depositAmount = double.Parse(Console.ReadLine());
                            account.Deposit(depositAmount);
                            Console.WriteLine("Deposit successful.");
                            break;
                        case "c":
                            Console.Write("Enter amount to withdraw: ");
                            double withdrawAmount = double.Parse(Console.ReadLine());
                            if (account.Withdraw(withdrawAmount))
                            {
                                Console.WriteLine("Withdrawal successful.");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient funds.");
                            }
                            break;
                        case "d":
                           
                            Console.WriteLine("======= Transactions =======\n");

                            Console.WriteLine($"Account Number {accountNumber}");
                            Console.WriteLine($"Account Name {accountHolderName}");
                            Console.WriteLine($"Annual Interest Rate :{interestRate}");
                            Console.WriteLine($"Account Balance :{account.Balance}");
                            foreach (var transaction in account.GetTransactions())
                            {

                                Console.WriteLine(transaction);
                            }
                            break;
                        case "e":
                            inAccountMenu = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }
}
