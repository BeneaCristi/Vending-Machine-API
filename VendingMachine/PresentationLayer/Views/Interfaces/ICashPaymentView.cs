namespace iQuest.VendingMachine.PresentationLayer.Views.Interfaces
{
    internal interface ICashPaymentView
    {
        float AskForMoney(double price, string name);
        void GiveBackChange(decimal rest);
    }
}