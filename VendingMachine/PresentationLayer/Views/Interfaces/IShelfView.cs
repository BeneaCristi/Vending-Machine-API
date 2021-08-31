using System.Collections.Generic;
using VendingMachineDomain.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace iQuest.VendingMachine.PresentationLayer.Views.Interfaces
{
    internal interface IShelfView
    {
        void DisplayProducts(IEnumerable<Product> p);
    }
}
