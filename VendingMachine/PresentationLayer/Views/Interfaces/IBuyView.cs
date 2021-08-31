using System.Collections.Generic;
using iQuest.VendingMachine.Payment.Services;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace iQuest.VendingMachine.PresentationLayer.Views.Interfaces
{
    internal interface IBuyView
    {
        int RequestId();
        bool ConfirmPayment();
        void DispenseProduct(string productName);
        int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}