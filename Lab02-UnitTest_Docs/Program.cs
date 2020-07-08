using System;

namespace Lab02_UnitTest_Docs
{
    public class BobsBodaciousBank
    {

        public static decimal Balance = 0.0m;

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
                Console.WriteLine("1.) Check your baller balance");
                Console.WriteLine("2.) Make a deposit");
                Console.WriteLine("3.) Make a withdrawal");
                Console.WriteLine("4.) Exit");
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
                            Withdrawal(0.00m);
                            break;
                        case 3:
                            break;
                        case 4:
                            bodacious = false;
                            break;
                        default:
                            Console.WriteLine("Something went wrong. Please choose again.");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter your choice as a number between 1 and 4.");
                    Console.WriteLine(e.Message);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("An OverflowException occurred.");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
                finally
                {
                    Console.WriteLine("Transaction complete. Please choose another or exit.");
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
        /// <param name="amount"></param>
        /// <returns>Decimal</returns>
        public static decimal Withdrawal(decimal amount)
        {
            if (amount < 0.00m)
            {
                throw new InvalidOperationException("Withdrawal amount must be ");
            }
            return ViewBalance();
        }

        /// <summary>
        /// Deposits the specified amount into the account. Only accepts positive numbers.
        /// Returns the balance after the deposit.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static decimal Deposit(decimal amount)
        {
            return ViewBalance();
        }
    }
}
