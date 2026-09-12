using CarDealershipFull.Excaptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipFull
{
    public class Bank
    {
        public decimal Balance { get; private set; } = 500000;
        public Bank(decimal initialBalance)
        {
            Balance = initialBalance;
        }
        public Bank()
        {
            
        }

        public List<Transaction> Transactions { get; set; } = new();
        public void Withdraw(decimal amount, string description)
        {
            if (amount <= 0) throw new ArgumentException("The amount must be greater than zero!");
            if (amount > Balance) throw new InsufficientFundsException();
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
        public void ShowSalesHistory()
        {
            Console.WriteLine("---------- CAR SALES HISTORY ----------");
            var sales =Transactions.Where(t=>t.Description != null && t.Description.Contains("sold")).ToList();
            if(sales.Count == 0)
            {
                Console.WriteLine("No car sales history found.");
                return;
            }
            foreach(var t in sales)
            {
                Console.WriteLine($"Date: {t.Date} | Type: {t.Type} | Amount: {t.Amount} AZN | Desc: {t.Description}");
            }
        }
        public void ShowRentalHistory()
        {
            Console.WriteLine("---------- RENTAL INCOME HISTORY ----------");
            var rental = Transactions.Where(t => t.Description != null && t.Description.Contains("rented")).ToList();
            if (rental.Count == 0)
            {
                Console.WriteLine("No rental history found.");
                return;
            }
            foreach (var t in rental)
            {
                Console.WriteLine($"Date: {t.Date} | Type: {t.Type} | Amount: {t.Amount} AZN | Desc: {t.Description}");
            }
        }
        public void ShowHistory()
        {
            Console.WriteLine("----------TRANSACTION HISTORY----------");
            foreach (var t in Transactions)
            {
                Console.WriteLine($"History: {t.Date} | Type: {t.Type} | Amount:{t.Amount} | Description: {t.Description}");
            }

        }

    }
}
