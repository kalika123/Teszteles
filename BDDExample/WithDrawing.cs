using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Be.Corebvba.Aubergine;

namespace Com.CodeProject.BDDExample
{
    class WithDrawing
    {
        Account _account = null;
        ATM _atm = null;
        Card _card = null;
        decimal AmountDispensed;
        public WithDrawing()
        {
            _account = new Account();
            _atm = new ATM();
            _card = new Card();
            _atm.Card = _card;
        }

        [DSL(@"The_account_balance_is_(?<amount>.+)")]
        void AccountBallanceIs(decimal amount)
        {
            _account.Balance = amount;
        }
        [DSL(@"the_card_is_(?<state>.+)")]
        void CardStateIs(CardState state)
        {
            _card.State = state;
        }

        [DSL(@"the_machine_contains_(?<amount>.+)")]
        void AtmContains(decimal amount)
        {
            _atm.AvailableCash = amount;
        }
        [DSL(@"the_Account_requests_(?<amount>.+)")]
        void Requests(decimal amount)
        {
            AmountDispensed = _atm.ProcessRequest(_account, amount);
        }

        [DSL]
        decimal enough_money()
        {
            return 1m;
        }

        [DSL(@"the_ATM_should_dispense_(?<amount>.+)")]
        bool dispensedShouldequal(decimal amount)
        {
            return AmountDispensed == amount;
        }

        [DSL(@"the_account_balance_should_be_(?<amount>.+)")]
        bool accbalShouldequal(decimal amount)
        {
            return _account.Balance == amount;
        }

        [DSL(@"the_ATM_should_say_(?<message>.+)")]
        bool atmmsg(string message)
        {
            return (_atm.Message ?? "").Replace(" ", "_").ToLower().Contains(message);
        }

        [DSL]
        bool the_ATM_should_not_give_any_money()
        {
            return AmountDispensed == 0;
        }
        [DSL]
        bool the_card_should_be_returned()
        {
            return _atm.Card == null;
        }

        [DSL]
        bool the_ATM_should_retain_the_card()
        {
            _atm.AddCardToRetainedCards(_card);
            return _atm.RetainedCards.Contains(_card);
        }

        
    }
}
