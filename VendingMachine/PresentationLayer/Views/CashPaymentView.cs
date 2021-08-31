using System;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.PresentationLayer.DisplayConfiguration;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal class CashPaymentView : DisplayBase, ICashPaymentView
    {
        public CashPaymentView() { }

        public virtual float AskForMoney(double price, string name)
        {
            Display("The ", ConsoleColor.White);
            Display($"{name}", ConsoleColor.Magenta);
            Display(" costs : ", ConsoleColor.White);
            Display($"{price} LEI\n", ConsoleColor.Green);
            Display("Please enter the money : ", ConsoleColor.Gray);

            string cashInput = Console.ReadLine();
            bool worked = double.TryParse(cashInput, out double moneyEntered);

            if (!worked)
            {
                Display("Please enter only money in the machine !!! \n\n", ConsoleColor.Red);
                return AskForMoney(price, name);
            }

            if (!(moneyEntered < Math.Pow(10, 29)))
            {
                return 1;
            }

            if (!(moneyEntered >= price))
            {
                Display($"\n\tYou entered : ", ConsoleColor.Gray);
                Display($"{moneyEntered} LEI\n", ConsoleColor.Green);
                Display($"\tYou still need : ", ConsoleColor.Gray);
                Display($"{Math.Round(price - moneyEntered, 2)} LEI ", ConsoleColor.Red);
                Display("more\n\n", ConsoleColor.Gray);
                return AskForMoney(Math.Round(price - moneyEntered, 2), name);
            }

            if (!(moneyEntered <= price))
            {
                Display($"\n\tYou entered : ", ConsoleColor.Gray);
                Display($"{moneyEntered} LEI\n", ConsoleColor.Green);

                GiveBackChange((decimal)(moneyEntered - price));
                return 0;
            }

            Display($"\n\tYou entered : ", ConsoleColor.Gray);
            Display($"{moneyEntered} LEI\n", ConsoleColor.Green);
            return 0;
        }

        public virtual void GiveBackChange(decimal rest)
        {
            decimal sute = 0;
            decimal zeci = 0;
            decimal lei = 0;
            decimal bani = 0;

            while (rest >= 100)
            {
                sute = Math.Truncate((rest / 100));
                rest %= 100;
            }
            while (rest >= 10)
            {
                zeci = Math.Truncate((rest / 10));
                rest %= 10;
            }
            while (rest >= 1)
            {
                lei = Math.Truncate((rest / 1));
                rest %= 1;
            }
            while (rest >= 0.01m)
            {
                bani = Math.Truncate((rest / 0.01m));
                rest %= 0.01m;
            }

            Display("\nYour ", ConsoleColor.Gray);
            Display("CHANGE", ConsoleColor.Yellow);
            Display(" will be : ", ConsoleColor.Gray);
            Display($"{sute}", ConsoleColor.Cyan);
            Display(" SUTE ", ConsoleColor.DarkGreen);
            Display($"{zeci}", ConsoleColor.Cyan);
            Display(" ZECI ", ConsoleColor.DarkGreen);
            Display($"{lei}", ConsoleColor.Cyan);
            Display(" LEI ", ConsoleColor.DarkGreen);
            Display($"{bani}", ConsoleColor.Cyan);
            Display(" BANI \n", ConsoleColor.DarkGreen);
        }
    }
}
