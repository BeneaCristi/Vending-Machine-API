
namespace iQuest.VendingMachine.PresentationLayer.Views.Interfaces
{
    internal interface ICommand
    {
        string Name { get; }

        string Description { get; }

        bool CanExecute { get; }

        void Execute();
    }
}
