using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("iQuest.VendingMachine")]


namespace VendingMachineDomain.Exceptions
{
    public class InsufficientStockException : Exception
    {
        private const string DefaultMessage = "We are out of stock !!";

        public InsufficientStockException()
            : base(DefaultMessage)
        {
        }

        public InsufficientStockException(string name)
            : base(String.Format($"\nWe don't have any more {name} in stock !"))
        {
        }
    }
}
