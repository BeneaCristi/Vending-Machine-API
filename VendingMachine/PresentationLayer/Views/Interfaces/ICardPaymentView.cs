namespace iQuest.VendingMachine.PresentationLayer.Views.Interfaces
{
    internal interface ICardPaymentView
    {
        string AskForCardNumber(float price, string name);
    }
}