using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Be.Corebvba.Aubergine;

namespace Com.CodeProject.BDDExample
{
    class Withdraws_cash : Story<WithDrawing>
    {
   
        class Successful_withdrawing : Scenario
        {
            Given The_account_balance_is_100;
            Given the_card_is_valid;
            Given the_machine_contains_enough_money;
            Given the_Account_requests_20;
            Then the_ATM_should_dispense_20;
            Then the_account_balance_should_be_80;
            Then the_card_should_be_returned;
        }
        class Failed_withdrawing : Scenario
        {
            Given The_account_balance_is_10;
            Given the_card_is_valid;
            Given the_machine_contains_enough_money;
            When the_Account_requests_20;
            Then the_ATM_should_not_give_any_money;
            Then the_ATM_should_say_there_are_insufficient_funds;
            Then the_account_balance_should_be_10;
            Then the_card_should_be_returned;
        }
        class Card_has_been_disabled : Scenario
        {
            Given the_card_is_disabled;
            When the_Account_requests_20;
            Then the_ATM_should_retain_the_card;
            Then 
        }
    }
}
