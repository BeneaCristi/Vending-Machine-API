using Autofac;

namespace iQuest.VendingMachine.ProgramConfiguration
{
    internal class Bootstrapper
    {
        public void Run()
        {
            IVendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static IVendingMachineApplication BuildApplication()
        {
            var container = ContainerConfig.Configure();
            return container.Resolve<IVendingMachineApplication>();
        }
    }
}