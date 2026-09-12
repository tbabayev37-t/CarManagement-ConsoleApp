using CarDealershipFull;
using CarDealershipFull.Excaptions;

Bank mainBank = new Bank(500000);
DealershipService saleService = new DealershipService(mainBank);
DealershipService rentService = new DealershipService(mainBank);

Console.WriteLine("----------Welcome to Cars World----------");

bool option = true;

while (option)
{
    Console.WriteLine("1.Car Sale");
    Console.WriteLine("2.Rent a Car");
    Console.WriteLine("3.Bank");
    Console.WriteLine("0.Exit");
    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.WriteLine("1.Add Car");
            Console.WriteLine("2.View Cars");
            Console.WriteLine("3.Delete Car");
            Console.WriteLine("4.Filter Cars");            
            Console.WriteLine("5.Sort Cars");            
            Console.WriteLine("6.Sell Car");            
            Console.WriteLine("0.Back");
            Console.Write("Choose an option: ");
            string choice1 = Console.ReadLine();
            switch (choice1)
            {
                case "1":
                    try
                    {
                        Console.Write("Car ID: ");
                        int carId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Car Brand: ");
                        string brandName = Console.ReadLine();
                        Console.Write("Car Model: ");
                        string model = Console.ReadLine();
                        Console.Write("Car Year: ");
                        int year = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Cost price: ");
                        int costPrice = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Sale price: ");
                        int salePrice = Convert.ToInt32(Console.ReadLine());
                        saleService.AddCar(carId,brandName,model,year,costPrice,salePrice);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Validation Error: {ex.Message}");
                    }
                    catch (InsufficientFundsException ex)
                    {
                        Console.WriteLine($"Business Error: {ex.Message}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Please enter a valid numeric value!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    }break;
                case "2":
                    try
                    {
                        saleService.GetAllCars();
                    }
                    catch( ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch(CarNotFoundException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                   break;
                case "3":
                    try
                    {
                        Console.Write("Enter the deleting car ID: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        saleService.DeleteCar(deleteId);
                    }
                    catch(CarNotFoundException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"General error: {ex.Message}");
                    }
                     break;
                case "4":
                    saleService.FilterCars(); break;
                case "5":
                    saleService.SortCars(); break;
                case "6":
                    try
                    {
                        saleService.SellCar();
                    }
                    catch (CarNotFoundException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }break;
                case "0":
                    goto EndOfSubMenu1;
                default:
                    Console.WriteLine("Incorrect choice! Try again.");
                    break;
            }
        EndOfSubMenu1:
         break;
        case "2":
            Console.WriteLine("1.Add Car");
            Console.WriteLine("2.View Cars");
            Console.WriteLine("3.Delete Car");
            Console.WriteLine("4.Filter Cars");
            Console.WriteLine("5.Sort Cars");
            Console.WriteLine("6.Sell Car");
            Console.WriteLine("0.Back");
            Console.Write("Choose an option: ");
            string choice2 = Console.ReadLine();
            switch (choice2)
            {
                case "1":
                    try
                    {
                        Console.Write("Car ID: ");
                        int carId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Car Brand: ");
                        string brandName = Console.ReadLine();
                        Console.Write("Car Model: ");
                        string model = Console.ReadLine();
                        Console.Write("Car Year: ");
                        int year = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Cost price: ");
                        int costPrice = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Sale price: ");
                        int salePrice = Convert.ToInt32(Console.ReadLine());
                        saleService.AddCar(carId, brandName, model, year, costPrice, salePrice);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Validation Error: {ex.Message}");
                    }
                    catch (InsufficientFundsException ex)
                    {
                        Console.WriteLine($"Business Error: {ex.Message}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Please enter a valid numeric value!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    }
                    break;
                case "2":
                    try
                    {
                        saleService.GetAllCars();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (CarNotFoundException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;
                case "3":
                    try
                    {
                        Console.Write("Enter the deleting car ID: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        saleService.DeleteCar(deleteId);
                    }
                    catch (CarNotFoundException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"General error: {ex.Message}");
                    }
                    break;
                case "4":
                    saleService.FilterCars(); break;
                case "5":
                    saleService.SortCars(); break;
                case "6":
                    try
                    {
                        saleService.SellCar();
                    }
                    catch(CarNotFoundException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch(FormatException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;
                case "0":
                    goto EndOfSubMenu2;
                default:
                    Console.WriteLine("Incorrect choice! Try again.");
                    break;
            }
            EndOfSubMenu2:
            break;
        case "3":
            Console.WriteLine("\n1.Bank Account");
            Console.WriteLine("2.Operations");
            Console.WriteLine("0.Exit");
            Console.Write("Choose an option: ");
            string option3 = Console.ReadLine();
            switch (option3)
            {
                case "1":
                    Console.WriteLine("---------Bank Account---------");
                    Console.WriteLine("1.Balance");
                    Console.WriteLine("2.Deposit");
                    Console.WriteLine("3.Withdraw");
                    Console.WriteLine("0.Back");
                    Console.Write("Choose an option: ");
                    string bankOption = Console.ReadLine();
                    switch (bankOption)
                    {
                        case "1":
                          Console.WriteLine($"Current balance: {mainBank.Balance} AZN"); break;
                        case "2":
                            try
                            {
                                Console.Write("Enter the amount:");
                                decimal amountD = decimal.Parse(Console.ReadLine());
                                mainBank.Deposit(amountD, $"{amountD} AZN money added to balance.");
                            }
                            catch(ArgumentException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        case "3":
                            try
                            {
                                Console.Write("Enter the amount: ");
                                decimal amountW = decimal.Parse(Console.ReadLine());

                                mainBank.Withdraw(amountW, $"{amountW} AZN withdraw.");
                                Console.WriteLine("Withdrawal successful!");
                            }
                            catch(InsufficientFundsException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Error: Please enter a valid numeric amount!");
                            }
                            catch(ArgumentException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                            }
                            break;
                        case "0":
                            goto BackOption;
                        default:
                            Console.WriteLine("Incorrect choice! Try again.");
                            break;
                    }
                    BackOption:
                    break;
                    
                case "2":
                    Console.WriteLine("---------Operations---------");
                    Console.WriteLine("1.Car Sales");
                    Console.WriteLine("2.Rental Income");
                    Console.WriteLine("3.History");
                    Console.WriteLine("0.Back");
                    Console.Write("Choose an option: ");
                    string OperationOption = Console.ReadLine();
                    switch (OperationOption)
                    {
                        case "1":
                            mainBank.ShowSalesHistory();
                            break;
                        case "2":
                            mainBank.ShowRentalHistory();
                            break;
                        case "3":                
                            mainBank.ShowHistory();
                            break;
                        case "0":
                            goto optionsBack;
                    }
                optionsBack:
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Incorrect choice! Try again.");
                    break;
            }
            break;
        case "0":
            option = false; break;
        default:
            Console.WriteLine("Incorrect choice! Try again.");
            break;
    }
}