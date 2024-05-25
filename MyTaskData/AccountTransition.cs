using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskData
{
    public enum AccountState { SignedIn, SignedOut }
    public enum TriggerAccountState { SignIn, SignOut }
    public class AccountTransition
    {
        public AccountState prevState;
        public AccountState nextState;
        public AccountState currentState;
        public TriggerAccountState triggerAccountState;

        public AccountTransition(AccountState prevState, AccountState nextState, TriggerAccountState trigger)
        {
            this.prevState = prevState;
            this.nextState = nextState;
            this.triggerAccountState = trigger;
        }

        private static AccountTransition[] transitions =
        {
            new AccountTransition(AccountState.SignedOut, AccountState.SignedIn, TriggerAccountState.SignIn),
            new AccountTransition(AccountState.SignedIn, AccountState.SignedOut, TriggerAccountState.SignOut)
        };

        public static AccountState getNextState(AccountState prevState, TriggerAccountState trigger)
        {
            AccountState nextState = prevState;
            for (int i = 0; i < transitions.Length; i++)
            {
                if (transitions[i].prevState == prevState && transitions[i].triggerAccountState == trigger)
                {
                    nextState = transitions[i].nextState;
                }
            }
            return nextState;
        }
    }
}
