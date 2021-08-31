using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("iQuest.VendingMachine")]

namespace VendingMachineDomain.Exceptions
{
    public class NoListException : Exception
    {
        private const string DefaultMessage = "The list is empty";

        public NoListException()
            : base(DefaultMessage)
        {
        }
    }
}
