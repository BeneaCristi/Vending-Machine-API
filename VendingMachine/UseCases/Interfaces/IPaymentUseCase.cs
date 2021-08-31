using System.Runtime.CompilerServices;
using iQuest.VendingMachine.Payment.Interfaces;
using iQuest.VendingMachine.Payment.Services;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace iQuest.VendingMachine.UseCases.Interfaces
{
    internal interface IPaymentUseCase
    {
        public PaymentMethod PaymentMethod { get; set; }
        IPaymentAlgorithm FindPaymentAlgorithm(string paymentMethodName);

        bool Execute(float price, string name);
    }
}
