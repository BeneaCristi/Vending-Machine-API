using System;
using iQuest.VendingMachine.UseCases.UseCaseList;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.PresentationLayer.DisplayConfiguration;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class ExitCommand : DisplayBase, ICommand
    {
        private readonly IUseCaseFactory useCaseFactory;

        public ExitCommand(IUseCaseFactory useCaseFactory)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public string Name => "Exit";

        public string Description => "   - Exit the application";

        public bool CanExecute => true;

        public void Execute()
        {
            useCaseFactory.Create<ExitUseCase>().Execute();
        }
    }
}
