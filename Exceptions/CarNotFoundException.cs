using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipFull.Excaptions
{
    public class CarNotFoundException:Exception
    {
        public CarNotFoundException():base("There are no machines available in the system.")
        {
            
        }
        public CarNotFoundException(string message):base(message) 
        {
            
        }
    }
}
