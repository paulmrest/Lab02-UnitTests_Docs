using System;

namespace Lab02_UnitTest_Docs
{
    public class BobsBodaciousBank
    {

        public static decimal Balance = 0.00m;

        static void Main(string[] args)
        {
            ATMInterface();
        }

        /// <summary>
        /// Main interface for ATM. Allows the user to view their balance, make a deposit, a withdrawal, or exit.
        /// </summary>
        public static void ATMInterface()
        {
            Console.WriteLine("Welcome to Bob's Bodacious Bank!");
            bool bodacious = true;
            while (bodacious)
            {
                Console.WriteLine("Please choose from one of the radical options below (1 to 4):");
                Console.WriteLine("1.) Check your baller balance!");
                Console.WriteLine("2.) Stow your stacks (desposit into your account)!");
                Console.WriteLine("3.) Get some green (withdraw from your account).");
                Console.WriteLine("4.) Skip on outta here! (Exit)");
                string userEntry = Console.ReadLine();
                try
                {
                    int userOption = Convert.ToInt32(userEntry);
                    if (userOption < 1 || userOption > 4)
                    {
                        throw new InvalidOperationException("Please choose a number between 1 and 4.");
                    }
                    switch (userOption)
                    {
                        case 1:
                            Console.WriteLine("Your current balance is: ${0}", ViewBalance());
                            break;
                        case 2:
                            Console.WriteLine("Please enter the amount you'd like to deposit:");
                            string desposit = Console.ReadLine();
                            decimal despositDec = Convert.ToDecimal(desposit);
                            decimal newDepBalance = Deposit(despositDec);
                            Console.WriteLine("After your deposit of ${0}, your balance is: ${1}", despositDec.ToString("F"), newDepBalance.ToString("F"));
                            break;
                        case 3:
                            Console.WriteLine("Please enter the amount you'd like to withdraw:");
                            string withdrawal = Console.ReadLine();
                            decimal withdrawalDec = Convert.ToDecimal(withdrawal);
                            decimal newWithdBalance = Withdrawal(withdrawalDec);
                            Console.WriteLine("After your withdrawal of ${0}, your balance is: ${1}", withdrawalDec.ToString("F"), newWithdBalance.ToString("F"));
                            break;
                        case 4:
                            Console.WriteLine("Thanks for banking bodaciously with Bob today!");
                            bodacious = false;
                            break;
                        default:
                            Console.WriteLine("Something went wrong. Please choose again.");
                            break;
                    }
                    if (userOption < 4)
                    {
                        Console.WriteLine("Transaction complete. Please choose another or exit.\n");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter your choice as a number between 1 and 4.");
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("An OverflowException occurred.");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Returns the current balance.
        /// </summary>
        /// <returns>Decimal</returns>
        public static decimal ViewBalance()
        {
            return Balance;
        }

        /// <summary>
        /// Removes the specified amount from the account. Will not allow account to drop below $0.00. 
        /// Only accept positive numbers. Returns the balance after the withdrawal.
        /// </summary>
        /// <param name="amount">Amount to be withdrawn</param>
        /// <returns>Decimal</returns>
        public static decimal Withdrawal(decimal amount)
        {
            if (amount < 0.00m)
            {
                throw new InvalidOperationException("Withdrawal amount must be a positive number");
            }
            else if (Balance - amount < 0)
            {
                throw new InvalidOperationException($"Withdrawal cannot exceed balance. Balance is currently: {Balance}");
            }
            else
            {
                Balance -= amount;
            }
            return ViewBalance();
        }

        /// <summary>
        /// Deposits the specified amount into the account. Only accepts positive numbers.
        /// Returns the balance after the deposit.
        /// </summary>
        /// <param name="amount">Amount to be deposited</param>
        /// <returns>Decimal</returns>
        public static decimal Deposit(decimal amount)
        {
            if (amount < 0.00m)
            {
                throw new InvalidOperationException("Deposit amount must be a positive number");
            }
            else
            {
                Balance += amount;
            }
            return ViewBalance();
        }
    }
}
