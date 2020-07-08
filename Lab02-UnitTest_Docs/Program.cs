using System;

namespace Lab02_UnitTest_Docs
{
    public class BobsBodaciousBank
    {

        public static decimal Balance;

        static void Main(string[] args)
        {
            ATMInterface();
        }

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
                            break;
                        case 2:
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
            }
        }
    }
}
