using CarDealershipFull.Excaptions;
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

            cars.Add(new Car { ID = 1, Brand = "BMW", Model = "M5", Year = 2022, CostPrice = 40000, SalePrice = 55000, IsRented = false });
            cars.Add(new Car { ID = 2, Brand = "Mercedes", Model = "C200", Year = 2020, CostPrice = 25000, SalePrice = 35000, IsRented = false });
            cars.Add(new Car { ID = 3, Brand = "Toyota", Model = "Camry", Year = 2021, CostPrice = 20000, SalePrice = 28000, IsRented = false });
        }
        public void AddCar()
        {
            Console.Write("Car ID: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            if (carId < 0) throw new ArgumentException("Invalid Id value!");//1

            Console.Write("Car Brand: ");
            string brandName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(brandName)) throw new ArgumentException("Brand name cannot be empty or whitespace.");//2

            Console.Write("Car Model: ");
            string model = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Model name cannot be empty or whitespace.");//3

            Console.Write("Car Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            if (year < 0 || year >2026) throw new ArgumentException("Invalid Year!");//4

            Console.Write("Cost price: ");
            int costPrice = Convert.ToInt32(Console.ReadLine());
            if (costPrice < 0) throw new ArgumentException("Invalid value!");//5

            Console.Write("Sale price: ");
            int salePrice = Convert.ToInt32(Console.ReadLine());
            if (salePrice < 0) throw new ArgumentException("Invalid value!");//6

            if (_bank.Balance < costPrice)
            {
                throw new InsufficientFundsException("There is not enough money in the bank balance!" +//7
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
                throw new CarNotFoundException();
            }
            foreach ( var Ac in cars )
            {
                Console.WriteLine($"Car {Ac.ID} | {Ac.Brand} | {Ac.Model}| {Ac.Year}| {Ac.CostPrice}AZN| {Ac.SalePrice}AZN| {Ac.IsRented}");
            }
        }
        public void DeleteCar()  
        {
            if(cars.Count == 0)
            {
                throw new CarNotFoundException();
            }
            Console.Write("Enter the deleting car ID: ");
            int deleteId = Convert.ToInt32(Console.ReadLine());
            var carToDelete = cars.FirstOrDefault(c=>c.ID == deleteId);
            if (carToDelete ==null)
            {
                throw new CarNotFoundException("This id machine was not found");
            }
            cars.Remove(carToDelete);
            Console.WriteLine($"{deleteId} ID car was delete");
        }  //masin silmek
        public void FilterCars()    // filtrlemek
        {
            Console.WriteLine("--------Filtering of cars--------");
            Console.WriteLine("1.Brand");
            Console.WriteLine("2.Year");
            Console.WriteLine("3.Price");
            Console.WriteLine("0.Back");
            Console.Write("Choose the option:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter the brand you are looking for: ");
                    string brand = Console.ReadLine();
                    var filteredByBrand = cars.Where(c=>c.Brand.Equals(brand,StringComparison.OrdinalIgnoreCase)).ToList();
                    PrintCars(filteredByBrand); break;
                case "2":
                    Console.Write("Enter the minimum year: ");
                    string year = Console.ReadLine();
                    if (int.TryParse(year, out int Year))
                    {
                        var filterByYear = cars.Where(c=>c.Year >= Year).ToList();
                        PrintCars(filterByYear); break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter the correct year!");
                    }
                    break;
                case "3":
                    Console.Write("Enter the maximum price: ");
                    decimal maxPrice = Convert.ToDecimal(Console.ReadLine());
                    var filteredByMaxPrice = cars.Where(c=>c.SalePrice <= maxPrice).ToList();
                    PrintCars(filteredByMaxPrice); break;
                case "0":
                    Console.WriteLine("Returning to the main menu...");
                    return;
                default:
                    Console.WriteLine("Incorrect choice! Try again.");
                    break;
            }
            
        }
        public void SortCars()
        {
            Console.WriteLine("--------Sorting of cars--------");
            Console.WriteLine("1.From cheap to expensive");
            Console.WriteLine("2.From expensive to cheap");
            Console.WriteLine("3.From old to new");
            Console.WriteLine("4.From new to old");
            Console.WriteLine("0.Back");
            Console.Write("Choose the option:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var orderByPrice = cars.OrderBy(c=>c.SalePrice).ToList(); 
                    PrintCars(orderByPrice);break;
                case "2":
                    var orderByDescendingPrice = cars.OrderByDescending(c => c.SalePrice).ToList();
                    PrintCars(orderByDescendingPrice); break;
                case "3":
                    var orderByYear = cars.OrderBy(c=>c.Year).ToList();
                    PrintCars(orderByYear); break;
                case "4":
                    var orderByDesYear = cars.OrderByDescending(c => c.Year).ToList();
                    PrintCars(orderByDesYear); break;
                case "0":
                    Console.WriteLine("Returning to the main menu...");
                    return;
                default:
                    Console.WriteLine("Incorrect choice! Try again.");
                    break;
            }
        }   //cesidlemek
        public void SellCar()
        {
            if (cars.Count == 0)
            {
                throw new CarNotFoundException();
            }
            Console.WriteLine("--------Avaliable cars--------");
            PrintCars(cars);
            Console.Write("Car Id:");
            string carId = Console.ReadLine();
            if (int.TryParse(carId, out int result))
            {
                var carToSell = cars.FirstOrDefault(c=>c.ID == result);
                if (carToSell == null)
                {
                    throw new CarNotFoundException("Error: Car with this ID was not found!");
                }
                _bank.Deposit(carToSell.SalePrice, $"{carToSell.Brand} {carToSell.Model} sold");
                cars.Remove(carToSell);
                Console.WriteLine($"Success! {carToSell.Brand} {carToSell.Model} was sold for {carToSell.SalePrice} AZN.");
            }
            else
            {
                Console.WriteLine("Please enter a valid numeric ID!");return;
            }
        }   //masin satmaq
        public void RentCar()
        {
            if (cars.Count == 0)
            {
                throw new CarNotFoundException("There are no cars available in the system to rent.");
            }

            Console.WriteLine("-------- Available Cars for Rent --------");
            PrintCars(cars);

            Console.Write("Enter the Car ID you want to rent: ");
            string inputId = Console.ReadLine();

            if (int.TryParse(inputId, out int carId))
            {
                var carToRent = cars.FirstOrDefault(c => c.ID == carId);

                if (carToRent == null)
                {
                    Console.WriteLine("Error: Car with this ID was not found!");
                    return;
                }
                if (carToRent.IsRented)
                {
                    Console.WriteLine("Error: This car is already rented out!");
                    return;
                }
                carToRent.IsRented = true;
                _bank.Deposit(carToRent.SalePrice, $"{carToRent.Brand} {carToRent.Model} rented out");

                Console.WriteLine($"Success! {carToRent.Brand} {carToRent.Model} was rented for {carToRent.SalePrice} AZN.");
            }
            else
            {
                Console.WriteLine("Please enter a valid numeric ID!");
            }
        }   // masin icare
        private void PrintCars(List<Car> carsToPrint)
        {
            if (carsToPrint.Count == 0)
            {
                Console.WriteLine("\nNo cars found matching these criteria.");
                return;
            }

            Console.WriteLine("\n--- Results ---");
            foreach (var car in carsToPrint)
            {
                Console.WriteLine($"ID: {car.ID} | {car.Brand} {car.Model} | Year: {car.Year} | Price: {car.SalePrice} AZN");
            }
        }

    }
}