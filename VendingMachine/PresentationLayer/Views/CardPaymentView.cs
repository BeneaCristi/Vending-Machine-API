using System;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.PresentationLayer.DisplayConfiguration;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal class CardPaymentView : DisplayBase, ICardPaymentView
    {

        public CardPaymentView() { }

        public string AskForCardNumber(float price, string name)
        {
            Display("Please enter a ", ConsoleColor.Gray);
            Display("CARD NUMBER ", ConsoleColor.Cyan);
            Display("like in the example below : \n\n", ConsoleColor.Gray);

            DrawCardExample();

            Display("The ", ConsoleColor.White);
            Display($"{name}", ConsoleColor.Magenta);
            Display(" costs : ", ConsoleColor.White);
            Display($"{price} LEI\n\n", ConsoleColor.Green);
            Display("Enter your ", ConsoleColor.Gray);
            Display("CARD NUMBER ", ConsoleColor.Cyan);
            Display(": ", ConsoleColor.White);

            string cardInput = Console.ReadLine();
            bool worked = long.TryParse(cardInput, out long cardNumber);


            if (!worked)
            {
                Display("Please enter a valid CARD NUMBER format !\n\n", ConsoleColor.Red);
                return AskForCardNumber(price, name);
            }

            if (!CheckLuhnAlgorithm(cardInput))
            {
                Display("Please enter a valid CARD NUMBER !\n\n", ConsoleColor.Red);
                return AskForCardNumber(price, name);
            }

            AskForPin();

            Display("The Payment is Processing ...\n", ConsoleColor.DarkGreen);
            return "1";
        }

        private bool CheckLuhnAlgorithm(string cardNumberString)
        {
            int[] cardInput = new int[cardNumberString.Length];
            int total = 0;

            for (int i = 0; i < cardNumberString.Length; i++)
            {
                cardInput[i] = (int)(cardNumberString[i] - '0');
            }

            for (int i = cardInput.Length - 2; i >= 0; i -= 2)
            {
                int value = cardInput[i];
                value *= 2;

                if (value > 9)
                {
                    value = value % 10 + 1;
                }

                cardInput[i] = value;
            }

            for (int i = 0; i < cardInput.Length; i++)
            {
                total += cardInput[i];
            }

            if (total % 10 == 0)
                return true;
            else
                return false;
        }

        private void DrawCardExample()
        {
            Display("\t\t\t\t\t\t\t\t\t===================================\n", ConsoleColor.DarkCyan);
            Display("\t\t\t\t\t\t\t\t\t|                                 |\n", ConsoleColor.DarkCyan);
            Display("\t\t\t\t\t\t\t\t\t|  ", ConsoleColor.DarkCyan);
            Display("iQUEST CARD", ConsoleColor.Yellow);
            Display("                    |\n", ConsoleColor.DarkCyan);
            Display("\t\t\t\t\t\t\t\t\t|                                 |\n", ConsoleColor.DarkCyan);
            Display("\t\t\t\t\t\t\t\t\t| ", ConsoleColor.DarkCyan); Display(" CARD NUMBER : ", ConsoleColor.Gray);
            Display("378282246310005", ConsoleColor.Cyan);
            Display("  |\n", ConsoleColor.DarkCyan);
            Display("\t\t\t\t\t\t\t\t\t|                                 |\n", ConsoleColor.DarkCyan);
            Display("\t\t\t\t\t\t\t\t\t| ", ConsoleColor.DarkCyan);
            Display(" PIN : ", ConsoleColor.Gray); Display("1111", ConsoleColor.Blue);
            Display("  (4 digit numbers)", ConsoleColor.DarkRed);
            Display("  |\n", ConsoleColor.DarkCyan);
            Display("\t\t\t\t\t\t\t\t\t===================================\n\n", ConsoleColor.DarkCyan);
            Display("(You can find more valid card numbers on : ", ConsoleColor.Gray);
            Display("https://www.freeformatter.com/credit-card-number-generator-validator.html )\n\n", ConsoleColor.Red);
        }

        private void AskForPin()
        {
            Display("Please enter your ", ConsoleColor.Gray);
            Display("PIN ", ConsoleColor.Blue);
            Display(": ", ConsoleColor.Gray);

            string pinInput = Console.ReadLine();
            bool worked = int.TryParse(pinInput, out int number);

            if (!worked || number < 999 || number > 10000)
            {
                Display($"\tThe PIN you entered is incorect\n", ConsoleColor.Red);

                AskForPin();
            }

            Display($"\nThe PIN you entered : ", ConsoleColor.White);
            Display($"{number}\n\n", ConsoleColor.Cyan);
        }
    }
}
