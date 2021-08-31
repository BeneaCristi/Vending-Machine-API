using System;

namespace VendingMachineDomain.Exceptions
{
    public class CancelledPaymentException : Exception
    {
        private const string DefaultMessage = "The PAYMENT is CANCELLED";

        public CancelledPaymentException()
            : base(DefaultMessage)
        {
        }
    }
}
