using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LightBDD;

namespace BDDTesting
{
    public partial class AccountContext : FeatureFixture
    {
        Account account = new Account();
        ATM atm = new ATM();
        Card card = new Card();
        decimal AmountDispensed;
        public AccountContext()
        {
            atm.Card = card;
        }
    //    [DSL(@"the_account_balance_is_(?<amount>.+)")]
        void the_account_balance_is(decimal amount)
        {
            account.Balance = amount;
        }
    //    [DSL(@"the_card_is_(?<state>.+)")]
        void the_card_is(CardState state)
        {
            card.State = state;
        }
    //    [DSL(@"the_machine_contains_(?<amount>.+)")]
        void the_machine_contains(decimal amount)
        {
            atm.AvailableCash = amount;
        }
   //     [DSL(@"the_Account_Holder_requests_(?<amount>.+)")]
        void the_account_Holder_requests(decimal amount)
        {
            AmountDispensed = atm.ProcessRequest(account, amount);
        }
   //     [DSL]
        decimal enough_money()
        {
            return 1m;
        }
    //    [DSL(@"the_ATM_should_dispense_(?<amount>.+)")]
        bool the_ATM_should_dispense(decimal amount)
        {
            return AmountDispensed == amount;
        }
    //    [DSL(@"the_account_balance_should_be_(?<amount>.+)")]
        bool the_account_balance_should_be(decimal amount)
        {
            return account.Balance == amount;
        }
      //  [DSL]
        bool the_ATM_should_not_dispense_any_money()
        {
            return AmountDispensed == 0;
        }
    //    [DSL]
        bool the_card_should_be_returned()
        {
            return atm.Card == null;
        }
   //     [DSL]
        bool the_ATM_should_retain_the_card()
        {
            return atm.RetainedCards.Contains(card);
        }
  //      [DSL(@"the_ATM_should_say_(?<message>.+)")]
        bool atmmsg(string message)
        {
            return (atm.Message ?? "").Replace(" ", "_").ToLower().Contains(message);
        }
    }
}
