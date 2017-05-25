using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.CodeProject.BDDExample
{
    class Account
    {
        public Decimal Balance { get; set; }
        public decimal WithDrawCash(decimal amount)
        {
            if (amount > Balance)
                return 0;
            Balance -= amount;
            return amount;
        }
    }
}
