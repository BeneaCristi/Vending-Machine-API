using System;
using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;


namespace iQuest.VendingMachine.PresentationLayer.DisplayConfiguration
{
    internal class CommandSelectorControl : DisplayBase
    {
        public IEnumerable<ICommand> UseCases { get; set; }

        public ICommand Display()
        {
            DisplayUseCases();
            return SelectUseCase();
        }

        private void DisplayUseCases()
        {
            Console.WriteLine();
            Console.WriteLine();
            Display(" Available commands\n", ConsoleColor.DarkCyan);
            Console.WriteLine();

            foreach (ICommand useCase in UseCases)
                DisplayUseCase(useCase);
        }

        private static void DisplayUseCase(ICommand useCase)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(useCase.Name);

            Console.ForegroundColor = oldColor;

            Console.WriteLine(useCase.Description);
        }

        private ICommand SelectUseCase()
        {
            while (true)
            {
                string rawValue = ReadCommandName();
                ICommand selectedUseCase = FindUseCase(rawValue);

                if (selectedUseCase != null)
                    return selectedUseCase;

                DisplayLine(" Invalid command. Please try again.", ConsoleColor.Red);
            }
        }

        private ICommand FindUseCase(string rawValue)
        {
            ICommand selectedUseCase = null;

            foreach (ICommand x in UseCases)
            {
                if (x.Name == rawValue)
                {
                    selectedUseCase = x;
                    break;
                }
            }

            return selectedUseCase;
        }

        private string ReadCommandName()
        {
            Console.WriteLine();
            Display(" Choose command : ", ConsoleColor.DarkCyan);
            string rawValue = Console.ReadLine();
            Console.WriteLine();

            return rawValue;
        }
    }
}