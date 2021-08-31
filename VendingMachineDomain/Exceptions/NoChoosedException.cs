using System;

namespace VendingMachineDomain.Exceptions
{
    public class NoChoosedException : Exception
    {
        private const string DefaultMessage = "The id entered is incorect";

        public NoChoosedException()
            : base(DefaultMessage)
        {
        }
    }
}
