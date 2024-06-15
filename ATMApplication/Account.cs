using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication
{
    internal class Account
    {
        public int AccountNumber { get; set; }
        public double Balance { get; private set; }
        public double InterestRate { get; set; }
        public string AccountHolderName { get; set; }
        private List<string> transactions;

        public Account(int accountNumber, double initialBalance, double interestRate, string accountHolderName)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            InterestRate = interestRate;
            AccountHolderName = accountHolderName;
            transactions = new List<string>();
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            transactions.Add($"Deposited: ${amount}");
        }

        public bool Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                transactions.Add($"Withdrew: ${amount}");
                return true;
            }
            else
            {
                transactions.Add($"Failed Withdrawal Attempt: ${amount}");
                return false;
            }
        }

        public List<string> GetTransactions()
        {
            return transactions;
        }

        public void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: ${Balance}");
            Console.WriteLine($"Interest Rate: {InterestRate}%");
        }
    }
    }
