using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipFull
{
    public class Car
    {
        public int ID {  get; set; }
        public string Brand { get; set; }=string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal CostPrice {  get; set; }
        public decimal SalePrice {  get; set; }
        public bool IsRented { get; set; }
    }
}
