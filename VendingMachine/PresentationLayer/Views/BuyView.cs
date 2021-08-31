using System;
using System.Collections.Generic;
using iQuest.VendingMachine.Payment.Services;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.PresentationLayer.DisplayConfiguration;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal class BuyView : DisplayBase, IBuyView
    {
        public int RequestId()
        {
            Display("\nPlease choose an option (enter Id number) : ", ConsoleColor.White);

            string input = Console.ReadLine();
            bool worked = int.TryParse(input, out int number);

            if (!worked)
            {
                Display("\n\tWrong Option , please enter a valid Id\n", ConsoleColor.Red);
                return RequestId();
            }

            Display("\n\tYou choosed the product with the ", ConsoleColor.Gray);
            Display($"ID : {input}\n", ConsoleColor.Green);
            return number;
        }

        public bool ConfirmPayment()
        {
            Display("\nPlease confirm the paymanet (press \"y\" for yes or \"n\" for no) : ", ConsoleColor.DarkYellow);

            string confirmationInput = Console.ReadLine();

            switch (confirmationInput)
            {
                case "y":
                    {
                        return true;
                    }
                case "n":
                    {
                        Display("\tThe confirmation was canceled\n", ConsoleColor.Red);
                        return false;
                    }
                default:
                    {
                        Display("\tNo valid option was selected\n", ConsoleColor.Red);
                        return false;
                    }
            }
        }

        public void DispenseProduct(string productName)
        {
            Display($"\n\tThe {productName} was delivered", ConsoleColor.Magenta);
        }

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {
            int[] options = { 1, 2 };

            Display("\n\t\t Please choose the PAYMENT method \n", ConsoleColor.Yellow);
            Display("\n(Type ", ConsoleColor.White);
            Display($"\"{options[0]}\" ", ConsoleColor.Cyan);
            Display("for CASH , ", ConsoleColor.White);
            Display($"\"{options[1]}\" ", ConsoleColor.Cyan);
            Display("for CREDIT CARD or ", ConsoleColor.White);
            Display("Any Other Key ", ConsoleColor.Red);
            Display("to CANCELL) : ", ConsoleColor.White);

            string choosePaymentInputString = Console.ReadLine();
            bool worked = int.TryParse(choosePaymentInputString, out int choosedPaymentInput);

            if (!worked || choosedPaymentInput > options.Length)
            {
                return 0;
            }

            foreach (var p in paymentMethods)
            {
                if (p.Id == choosedPaymentInput)
                {
                    Display("\nYou choosed payment with : ", ConsoleColor.Gray); 
                    Display($"{p.Name}\n\n", ConsoleColor.Green);
                }
            }
            return choosedPaymentInput;
        }
    }
}
