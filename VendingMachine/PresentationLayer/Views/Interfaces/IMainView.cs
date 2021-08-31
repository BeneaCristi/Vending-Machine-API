using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer.Views.Interfaces
{
    internal interface IMainView
    {
        ICommand ChooseCommand(IEnumerable<ICommand> useCases);
        void DisplayApplicationHeader();
    }
}