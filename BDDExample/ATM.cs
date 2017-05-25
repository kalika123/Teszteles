using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.CodeProject.BDDExample
{
    class ATM
    {
        public Card Card { get; set; }
        public decimal AvailableCash { get; set; }
        public List<Card> RetainedCards { get; private set; }
        public string Message { get; private set; }

        public void AddCardToRetainedCards(Card card)
        {
            RetainedCards.Add(card);
        }

        public ATM()
        {
            RetainedCards = new List<Card>();
        }

        public decimal ProcessRequest(Account account,decimal amount)
        {
            var cash = account.WithDrawCash(amount);
            if (cash == 0)
                Message = "There are insufficient funds available on your account";
            else
                Message = "Please take your cash";
            Card = null;
            return cash;
        }
    }
}
