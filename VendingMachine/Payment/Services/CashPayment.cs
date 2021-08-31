using VendingMachineDomain.Exceptions;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.Payment.Interfaces;

namespace iQuest.VendingMachine.Payment.Services
{
    internal class CashPayment : IPaymentAlgorithm
    {
        public ICashPaymentView cashView { get; set; }
        public string Name { get => "CASH"; }

        public CashPayment(ICashPaymentView cashView)
        {
            this.cashView = cashView;
        }

        public virtual void Run(float price, string name)
        {
            if (cashView.AskForMoney(price, name) == 1)
            {
                throw new TooMuchMoneyException();
            }
        }
    }
}
