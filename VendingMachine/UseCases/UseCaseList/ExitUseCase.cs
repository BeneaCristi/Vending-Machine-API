using System;
using iQuest.VendingMachine.UseCases.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]

namespace iQuest.VendingMachine.UseCases.UseCaseList
{
    internal class ExitUseCase : IUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Execute()
        {
            log.Info("Application Closed\n");

            Environment.Exit(0);
        }
    }
}
