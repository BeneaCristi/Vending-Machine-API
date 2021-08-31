using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("iQuest.VendingMachine")]

namespace VendingMachineDomain.Exceptions
{
    public class InvalidProductIdException : Exception
    {
        private const string DefaultMessage = "The id entered is incorect";

        public InvalidProductIdException()
            : base(DefaultMessage)
        {
        }
    }
}
