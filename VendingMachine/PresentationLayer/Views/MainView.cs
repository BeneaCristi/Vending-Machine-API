using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.PresentationLayer.DisplayConfiguration;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal class MainView : DisplayBase, IMainView
    {
        public void DisplayApplicationHeader()
        {
            ApplicationHeaderControl applicationHeaderControl = new ApplicationHeaderControl();
            applicationHeaderControl.Display();
        }

        public ICommand ChooseCommand(IEnumerable<ICommand> useCases)
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl
            {
                UseCases = useCases
            };
            return commandSelectorControl.Display();
        }
    }
}