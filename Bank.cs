using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipFull
{
    public class Bank
    {
        public decimal Balance { get; private set; } = 500;
        public Bank(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        List<Transaction> Transactions { get; set; } = new();
        public void Withdraw(decimal amount, string description)
        {
            if (amount <= 0) throw new ArgumentException("The amount must be greater than zero!");
            if (amount > Balance) throw new ArgumentException("There are not money in balance! The salon is closing...");
            Balance -= amount;

            Transactions.Add(new Transaction
            {
                Description = description,
                Amount = amount,
                Type = "Expense",
                Date = DateTime.UtcNow
            });
        }
        public void Deposit(decimal amount, string description)
        {
            if (amount <= 0) throw new ArgumentException("The amount must be greater than zero!");
            Balance += amount;
            Transactions.Add(new Transaction
            {
                Description = description,
                Amount = amount,
                Type = "Income",
                Date = DateTime.UtcNow
            });
        }
        public void ShowHistory(decimal balance)
        {
            Console.WriteLine("----------TRANSACTION HISTORY----------");
            foreach (var t in Transactions)
            {
                Console.WriteLine($"History: {t.Date} | Type: {t.Type} | Amount:{t.Amount} | Description: {t.Description}");
            }

        }

    }
}
