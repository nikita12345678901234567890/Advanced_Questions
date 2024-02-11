namespace ADV_207
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Bank:

            Deposit(presume inputs are ok), withdraw(cannot overdraw), check balance, lock account(no withdraw, throw error)

            no conditionals

            "overdrawn" means balance became negative, equates to lockout

            no bool lockedOut

            this is an OOP assignment, think OOP, not a math trick assignment

            do login, when account starts out it is not in authenticated state
            when in that state, everything throws
            authenticate() doesn't have to check username/password

            deposit function allowed if statement to check if not overdrawn anymore, but if statement doesn't exist if not locked out

            can you do silent failure??????  -Stan

            New Rules:
            cannot throw random-ass errors
            */
        }
    }

    public class Account
    { 
        public int Balance { get; private set; }



        public Account() { }

        public void Authenticate()
        { 
            
        }

        public void Deposit(int amount)
        {
            Balance += amount;
        }

        public void Withdraw(int amount)
        { 
            Balance -= amount;

            if (Balance < 0)
            { 
                //Do cool shit here
            }
        }
    }
}