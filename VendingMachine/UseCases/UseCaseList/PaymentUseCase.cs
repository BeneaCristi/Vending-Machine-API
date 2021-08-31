using System;
using System.Linq;
using iQuest.VendingMachine.Payment.Services;
using iQuest.VendingMachine.Payment.Interfaces;
using System.Collections.Generic;
using VendingMachineDomain.Exceptions;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;

namespace iQuest.VendingMachine.UseCases.UseCaseList
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PaymentMethod PaymentMethod { get; set; }    

        private List<IPaymentAlgorithm> paymentAlgorithms;
        private readonly IBuyView buyView; 

        public List<PaymentMethod> paymentMethods = new List<PaymentMethod>()
        {
            new PaymentMethod(1,"CASH"),
            new PaymentMethod(2,"CREDIT CARD")
        };

        public PaymentUseCase(IEnumerable<IPaymentAlgorithm> paymentAlgorithms, IBuyView buyView)
        {
            this.paymentAlgorithms = paymentAlgorithms.ToList() ?? throw new ArgumentNullException(nameof(paymentAlgorithms));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
        }

        public IPaymentAlgorithm FindPaymentAlgorithm(string paymentMethodName)
        {
            IPaymentAlgorithm selectedPaymentAlgorithm = null;

            foreach (IPaymentAlgorithm paymentAlgorithm in paymentAlgorithms)
            {
                if (paymentAlgorithm.Name == paymentMethodName)
                {
                    selectedPaymentAlgorithm = paymentAlgorithm;
                    break;
                }
            }
            return selectedPaymentAlgorithm;
        }

        public virtual bool Execute(float price, string name)
        {
            int chooser = buyView.AskForPaymentMethod(paymentMethods);

            if (chooser < 1 || chooser > 2)
            {
                throw new CancelledPaymentException();
            }

            foreach (var p in paymentMethods)
            {
                if (p.Id == chooser)
                {
                    PaymentMethod = p;
                    FindPaymentAlgorithm(p.Name).Run(price, name);
                }
            }

            if (!buyView.ConfirmPayment())
            {
                log.Info("Confirmation was cancelled\n");
                return false;
            }

            log.Info($"User PAYED for {name}\n");
            return true;
        }
    }
}
