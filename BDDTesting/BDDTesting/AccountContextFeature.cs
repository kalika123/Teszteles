using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDTesting
{
    [TestFixture]
    [FeatureDescription(
        @"In order to support last-in-first-out (LIFO) operations
        As an developer
        I want to use a stack")]
    [Label("LIFO")]
    public partial class AccountContext
    {
        [Test]
        [Label("Empty")]
        public void Empty_stack()
        {
            Runner.RunScenario(

                given => the_account_balance_is(100),
                given => the_card_is(CardState.Valid));
              
        }

        [Test]
        [Label("Not empty")]
        public void Non_empty_stack()
        {
            Runner.RunScenario(

                given => a_non_empty_stack(),
                when => calling_peek(),
                then => it_returns_the_top_element(),
                but => it_does_not_remove_the_top_element(),
                when => calling_pop(),
                then => it_returns_the_top_element(),
                and => it_removes_the_top_element());
        }
    }
}
