using System;

namespace VendingMachineDomain.Exceptions
{
    public class TooMuchMoneyException : Exception
    {
        private const string DefaultMessage = "You are too RICH , go buy your own Vending Machine";

        public TooMuchMoneyException()
            : base(DefaultMessage)
        {
        }
    }
}
