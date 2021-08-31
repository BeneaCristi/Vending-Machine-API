using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace iQuest.VendingMachine.PresentationLayer.Views.Interfaces
{
    internal interface ILoginView
    {
        string AskForPassword();
    }
}