using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipFull
{
    public class DealershipService
    {
        public List<Car> cars = new List<Car>(10000);
        public Bank _bank;
        public DealershipService(Bank bank)
        {
            _bank = bank;
        }
        public void AddCar()
        {
            Console.Write("Car ID: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            if (carId < 0) throw new ArgumentException("Invalid Id value!");

            Console.Write("Car Brand: ");
            string brandName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(brandName)) throw new ArgumentException("Brand name cannot be empty or whitespace.");

            Console.Write("Car Model: ");
            string model = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Model name cannot be empty or whitespace.");

            Console.Write("Car Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            if (year < 0 && year >2026) throw new ArgumentException("Invalid Year!");

            Console.Write("Cost price: ");
            int costPrice = Convert.ToInt32(Console.ReadLine());
            if (costPrice < 0) throw new ArgumentException("Invalid value!");

            Console.Write("Sale price: ");
            int salePrice = Convert.ToInt32(Console.ReadLine());
            if (costPrice < 0) throw new ArgumentException("Invalid value!");

            if (_bank.Balance < costPrice)
            {
                throw new ArgumentException("There is not enough money in the bank balance!" +
                    "\nThe car cannot be purchased because the showroom does not have enough money. THE SALON IS CLOSING!");
            }
            _bank.Withdraw(costPrice, $"{brandName} {model} purchase price");

            Car newCar = new Car()
            {
                ID = carId,
                Brand = brandName,
                Model = model,
                Year = year,
                CostPrice = costPrice,
                SalePrice = salePrice,
                IsRented = false
            };
            cars.Add(newCar);
            Console.WriteLine($"Successful! {brandName} {model} has been added to the system. Current balance: {_bank.Balance} AZN");
        }  // masin elave etmek
        public void GetAllCars()  // masinlara baxmaq
        {
            Console.WriteLine("\n----------Available cars----------");
            if (cars.Count == 0)
            {
                Console.WriteLine("There are no machines available in the system.");
                return;
            }
            foreach ( var Ac in cars )
            {
                Console.WriteLine($"Car {Ac.ID} | {Ac.Brand} | {Ac.Model}| {Ac.Year}| {Ac.CostPrice}AZN| {Ac.SalePrice}AZN| {Ac.IsRented}");
            }
        }
    }
}