using System;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.PresentationLayer.DisplayConfiguration;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal class ReportsView : DisplayBase, IReportsView
    {
        public void TellFileFormat(string format)
        {
            Display("The format choosed is : ", ConsoleColor.Gray);
            Display($"{format.ToUpper()}\n", ConsoleColor.Red);
            Display("To change the format please acces the App.config file\n\n", ConsoleColor.Blue);
        }

        public void CreatedMessage(string option, string reportsFolder)
        {
            Display("\nThe ", ConsoleColor.Gray);
            Display($"{option}", ConsoleColor.Cyan);
            Display(" that you requested was ", ConsoleColor.Gray);
            Display("CREATED.\n", ConsoleColor.Green);
            Display($"You cand find it in VendingMachine -> UseCases -> Reports -> SerializedObjects -> {option.ToUpper()} -> {reportsFolder}",ConsoleColor.Blue);
        }

        public DateTime AskForADate(string dateTime)
        {
            Display("Please enter a ", ConsoleColor.Gray);
            Display($"{dateTime} DATE ", ConsoleColor.Green);
            Display("(yyyy-MM-dd)", ConsoleColor.DarkGreen);
            Display(" : ", ConsoleColor.Gray);

            string input = Console.ReadLine();
            bool worked = DateTime.TryParse(input, out DateTime date);

            if(!worked)
            {
                Display("\n\tWrong Date Format , please enter a valid format\n\n", ConsoleColor.Red);
                return AskForADate(dateTime);
            }

            return date;
        }
    }
}
