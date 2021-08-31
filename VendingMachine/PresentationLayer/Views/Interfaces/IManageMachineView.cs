namespace iQuest.VendingMachine.PresentationLayer.Views.Interfaces
{
    internal interface IManageMachineView
    {
        int AskOption();
        int RequestId(/*int maxIdNumber*/);
        string AskForNewName();
        int AskForNewStock();
        double AskForNewPrice();
        void ShowDeleteMessage(int id, string name);
    }
}