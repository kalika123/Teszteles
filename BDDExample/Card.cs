using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.CodeProject.BDDExample
{
    class Card
    {
        public CardState State { get; set; }

    }
    public enum CardState
    {
        Valid,
        Disabled
    }
}
