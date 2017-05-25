using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDTesting
{
    class Card
    {
        public CardState State { get; set; }

        enum CardState
        {
            Valid,
            Disabled
        }
    }
}
