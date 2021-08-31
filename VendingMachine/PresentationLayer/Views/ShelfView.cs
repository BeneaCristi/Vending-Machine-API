using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachineDomain.Models;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.PresentationLayer.DisplayConfiguration;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal class ShelfView : DisplayBase, IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> list)
        {
            if (list is null || !list.Any())
            {
                Display("The vending machine is empty", ConsoleColor.Red);
                return;
            }

            foreach (var i in list)
            {
                Display("The ", ConsoleColor.White);
                Display($"{i.Name}", ConsoleColor.Cyan);
                Display(" has the ID: ", ConsoleColor.White);
                Display($"{i.Id}", ConsoleColor.Yellow);
                Display(" the price of ", ConsoleColor.White);
                Display($"{i.Price} LEI ", ConsoleColor.Green);
                Display("and we have only ", ConsoleColor.White);
                Display($"{i.Quantity}", ConsoleColor.Red);
                Display(" left\n", ConsoleColor.White);
            }
        }
    }
}
