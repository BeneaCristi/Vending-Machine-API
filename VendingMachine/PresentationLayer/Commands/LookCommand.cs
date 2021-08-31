using System;
using iQuest.VendingMachine.UseCases.UseCaseList;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class LookCommand : ICommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        public string Name => "Look";

        public string Description => "   - Look inside the vending machine\n";

        public bool CanExecute => true;

        public LookCommand(IUseCaseFactory useCaseFactory)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<LookUseCase>().Execute();
        }
    }
}
