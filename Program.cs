using CarDealershipFull;

Bank mainBank = new Bank(5000);
DealershipService saleService = new DealershipService(mainBank);
DealershipService rentService = new DealershipService(mainBank);

Console.WriteLine("----------Welcome to Cars World----------");
Console.WriteLine("1.Car Sale");
Console.WriteLine("2.Rent a Car");
Console.WriteLine("3.Bank");
Console.WriteLine("0.Exit");
bool option = true;
string choice = Console.ReadLine();
while (option)
{
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
            string choice1 = Console.ReadLine();
            switch (choice1)
            {
                case "1":
                    saleService.AddCar();break;
                case "2":
                    saleService.GetAllCars();break;
                case "3":
                    saleService.DeleteCar(); break;
                case "4":
                    saleService.FilterCars(); break;
                case "5":
                    saleService.SortCars(); break;
                case "6":
                    saleService.SellCar(); break;
                case "0":
                    goto EndOfSubMenu;
            }
        EndOfSubMenu:
            break;

    }

}
