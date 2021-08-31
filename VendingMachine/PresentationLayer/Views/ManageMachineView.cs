using System;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.PresentationLayer.DisplayConfiguration;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal class ManageMachineView : DisplayBase, IManageMachineView
    {

        public int AskOption()
        {
            ShowOptions();
            string input = Console.ReadLine();
            bool worked = int.TryParse(input, out int number);

            if (!worked || number < 1 || number > 5)
            {
                Display("\n\n\tPLEASE CHOOSE A VALID OPTION !\n\n\n", ConsoleColor.Red);
                return AskOption();
            }

            switch(number)
            {
                case 1:
                    {
                        Display("\nYou choosed the ", ConsoleColor.Gray);
                        Display("ADD", ConsoleColor.Green);
                        Display(" option\n", ConsoleColor.Gray);
                        return number;
                    }
                case 2:
                    {
                        Display("\nYou choosed the ", ConsoleColor.Gray);
                        Display("DELETE", ConsoleColor.Red);
                        Display(" option\n", ConsoleColor.Gray);
                        return number;
                    }
                case 3:
                    {
                        Display("\nYou choosed the ", ConsoleColor.Gray);
                        Display("UPDATE NAME", ConsoleColor.Magenta);
                        Display(" option\n", ConsoleColor.Gray);
                        return number;
                    }
                case 4:
                    {
                        Display("\nYou choosed the ", ConsoleColor.Gray);
                        Display("UPDATE STOCK", ConsoleColor.Magenta);
                        Display(" option\n", ConsoleColor.Gray);
                        return number;
                    }
                case 5:
                    {
                        Display("\nYou choosed the ", ConsoleColor.Gray);
                        Display("UPDATE PRICE", ConsoleColor.Magenta);
                        Display(" option\n", ConsoleColor.Gray);
                        return number;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        public int RequestId()
        {
            Display("\nPlease insert the ", ConsoleColor.Gray);
            Display("ID", ConsoleColor.Yellow);
            Display(" : ", ConsoleColor.Gray);

            string input = Console.ReadLine();
            bool worked = int.TryParse(input, out int number);

            if(!worked)
            {
                Display("\n\n\tPlease choose a valid id format !\n\n\n", ConsoleColor.Red);
                return RequestId();
            }

            return number;
        }

        public string AskForNewName()
        {
            Display("Please enter a new ", ConsoleColor.Gray);
            Display("NAME", ConsoleColor.Magenta);
            Display(" : ", ConsoleColor.Gray);

            string name = Console.ReadLine();

            Display("\nThe name was changed succesfully\n", ConsoleColor.DarkGreen);
            return name;
        }

        public int AskForNewStock()
        {
            Display("Please enter a new ", ConsoleColor.Gray);
            Display("STOCK", ConsoleColor.Yellow);
            Display(" : ", ConsoleColor.Gray);
           
            string stock = Console.ReadLine();
            bool worked = int.TryParse(stock, out int number);
            
            if(!worked || number < 0)
            {
                Display("\nNo valid stock amount was selected , please try again\n", ConsoleColor.Red);
                return AskForNewStock();
            }

            Display("\nThe stock was changed succesfully\n", ConsoleColor.DarkGreen);
            return number;
        }

        public double AskForNewPrice()
        {
            Display("Please enter a new ", ConsoleColor.Gray);
            Display("PRICE", ConsoleColor.Green);
            Display(" : ", ConsoleColor.Gray);

            string price = Console.ReadLine();
            bool worked = double.TryParse(price, out double number);

            if (!worked || number < 0)
            {
                Display("\nNo valid stock amount was selected , please try again\n", ConsoleColor.Red);
                return AskForNewPrice();
            }

            Display("\nThe price was changed succesfully\n", ConsoleColor.DarkGreen);
            return number;
        }

        private void ShowOptions()
        {
            Display("To ", ConsoleColor.Gray);
            Display("ADD ", ConsoleColor.Green);
            Display("a new type of product in the machine please press               ", ConsoleColor.Gray);
            Display("1\n", ConsoleColor.Cyan);
            Display("To ", ConsoleColor.Gray);
            Display("DELETE ", ConsoleColor.Red);
            Display("an existing type of product from the machine please press    ", ConsoleColor.Gray);
            Display("2\n", ConsoleColor.Cyan);
            Display("To ", ConsoleColor.Gray);
            Display("UPDATE", ConsoleColor.Magenta);
            Display(" the ", ConsoleColor.Gray);
            Display("NAME", ConsoleColor.Blue);
            Display(" of a product please press                           ", ConsoleColor.Gray);
            Display("3\n", ConsoleColor.Cyan);
            Display("To ", ConsoleColor.Gray);
            Display("UPDATE", ConsoleColor.Magenta);
            Display(" the ", ConsoleColor.Gray);
            Display("STOCK", ConsoleColor.Blue);
            Display(" of a product please press                          ", ConsoleColor.Gray);
            Display("4\n", ConsoleColor.Cyan);
            Display("To ", ConsoleColor.Gray);
            Display("UPDATE", ConsoleColor.Magenta);
            Display(" the ", ConsoleColor.Gray);
            Display("PRICE", ConsoleColor.Blue);
            Display(" of a product please press                          ", ConsoleColor.Gray);
            Display("5\n", ConsoleColor.Cyan);
            Display("\n\tPlease choose an option : ", ConsoleColor.DarkYellow);
        }

        public void ShowDeleteMessage(int id, string name)
        {
            Display("\nAll products with the id ", ConsoleColor.DarkRed);
            Display($"{id}", ConsoleColor.Yellow);
            Display(" were deleted. There are no more ", ConsoleColor.DarkRed);
            Display($"{name}s", ConsoleColor.Magenta);
            Display(" in the machine", ConsoleColor.DarkRed);
        }
    }
}