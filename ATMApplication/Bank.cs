using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication
{
    internal class Bank
    {

        //creatint the list to store the accounts
        private List<Account> accounts;


        // Constructor to initialize the accounts list and add default accounts
        public Bank()
        {
            accounts = new List<Account>();
            for (int i = 100; i < 110; i++)
            {
                accounts.Add(new Account(i, 100.0, 3.0, $"Default Account {i}"));
            }
        }

        // Method to add a new account
        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account RetrieveAccount(int accountNumber)
        {
            return accounts.Find(acc => acc.AccountNumber == accountNumber);
        }
        // Method to display all accounts
        public void DisplayAllAccounts()
        {
            foreach (var account in accounts)
            {
                account.DisplayAccountInfo();
                Console.WriteLine();
            }
        }
    }
    }
