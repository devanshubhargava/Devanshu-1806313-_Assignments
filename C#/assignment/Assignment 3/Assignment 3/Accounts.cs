using System;

namespace Assignment3

{

    internal class Accounts

    {

        private string accountNo;

        private string customerName;

        private string accountType;

        private int balance;

        public Accounts(string accountNo, string customerName, string accountType, int initialBalance)

        {

            this.accountNo = accountNo;

            this.customerName = customerName;

            this.accountType = accountType;

            this.balance = initialBalance;

        }

        public void Credit(int amount)

        {

            balance += amount;

            Console.WriteLine($"Deposited {amount}. New balance: {balance}");

        }

        public void Debit(int amount)

        {

            if (amount <= balance)

            {

                balance -= amount;

                Console.WriteLine($"Withdrew {amount}. New balance: {balance}");

            }

            else

            {

                Console.WriteLine($"Insufficient funds for withdrawal of {amount}. Current balance: {balance}");

            }

        }

        public void ProcessTransaction(string transactionType, int amount)

        {

            if (transactionType == "D")

            {

                Credit(amount);

            }

            else if (transactionType == "W")

            {

                Debit(amount);

            }

            else

            {

                Console.WriteLine("Invalid transaction type. Use 'D' for Deposit or 'W' for Withdrawal.");

            }

        }

        public void ShowData()

        {

            Console.WriteLine($"Account No: {accountNo}");

            Console.WriteLine($"Customer Name: {customerName}");

            Console.WriteLine($"Account Type: {accountType}");

            Console.WriteLine($"Balance: {balance}");

        }

        static void Main(string[] args)

        {

            Console.Write("Enter Account Number: ");

            string accountNo = Console.ReadLine();

            Console.Write("Enter Customer Name: ");

            string customerName = Console.ReadLine();

            Console.Write("Enter Account Type (e.g., Savings, Checking): ");

            string accountType = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");

            int initialBalance = int.Parse(Console.ReadLine());

            Accounts account = new Accounts(accountNo, customerName, accountType, initialBalance);

            account.ShowData();

            string transactionType;

            do

            {

                Console.Write("\nEnter transaction type (D for Deposit, W for Withdrawal, Q to quit): ");

                transactionType = Console.ReadLine().ToUpper();

                if (transactionType == "D" || transactionType == "W")

                {

                    Console.Write("Enter the amount: ");

                    int amount = int.Parse(Console.ReadLine());

                    account.ProcessTransaction(transactionType, amount);

                    account.ShowData();

                }

                else if (transactionType != "Q")

                {

                    Console.WriteLine("Invalid transaction type. Please enter 'D', 'W', or 'Q'.");

                }

            } while (transactionType != "Q");

            Console.WriteLine("\nFinal Account Details:");

            account.ShowData();

            Console.ReadLine();

        }

    }

}
