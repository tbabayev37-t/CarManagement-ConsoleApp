using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipFull.Excaptions
{
    public class InsufficientFundsException:Exception
    {
        public InsufficientFundsException():base("There are insufficient funds in the balance!")
        {
            
        }
        public InsufficientFundsException(string message)
        : base(message) { }

    }
}
