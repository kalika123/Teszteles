using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDTesting
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
