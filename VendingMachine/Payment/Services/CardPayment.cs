using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.Payment.Interfaces;

namespace iQuest.VendingMachine.Payment.Services
{
    internal class CardPayment : IPaymentAlgorithm
    {
        public ICardPaymentView cardView { get; set; }
        public string Name { get => "CREDIT CARD"; }

        public CardPayment(ICardPaymentView cardView)
        {
            this.cardView = cardView;
        }

        public void Run(float price, string name)
        {
            cardView.AskForCardNumber(price, name);
        }
    }
}
