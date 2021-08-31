using System;
using VendingMachineDomain.Exceptions;
using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.PresentationLayer.DisplayConfiguration;


namespace iQuest.VendingMachine.ProgramConfiguration
{
    internal class VendingMachineApplication : DisplayBase, IVendingMachineApplication
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IEventViewerErrorWriter eventWriter;
        private readonly IEnumerable<ICommand> useCases;
        private readonly IMainView mainView;

        public VendingMachineApplication(IEnumerable<ICommand> useCases, IMainView mainView, IEventViewerErrorWriter eventWriter)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
            this.eventWriter = eventWriter ?? throw new ArgumentNullException(nameof(eventWriter));
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                try
                {
                    List<ICommand> availableUseCases = GetExecutableUseCases();

                    ICommand useCase = mainView.ChooseCommand(availableUseCases);
                    useCase.Execute();
                }
                catch (InsufficientStockException e)
                {
                    Display("\n\tWE DON'T HAVE ANY MORE STOCK !!!", ConsoleColor.Red);
                    log.Error(e + "\n");
                    eventWriter.EventLogger(e.ToString());
                }
                catch (InvalidPasswordException e)
                {
                    Display("\n\t YOU ENTERED AN INCORECT PASSWORD !!!", ConsoleColor.Red);
                    log.Error(e + "\n");
                    eventWriter.EventLogger(e.ToString());
                }
                catch (InvalidProductIdException e)
                {
                    Display("\n\tYOU ENTERED A WRONG ID !!! ", ConsoleColor.Red);
                    log.Error(e + "\n");
                    eventWriter.EventLogger(e.ToString());
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Display("\n\tYOU ENTERED A WRONG ID !!! ", ConsoleColor.Red);
                    log.Error(e + "\n");
                    eventWriter.EventLogger(e.ToString());
                }
                catch (NoChoosedException e)
                {
                    Display("\n\t The Payment was cancelled", ConsoleColor.Red);
                    log.Error(e + "\n");
                    eventWriter.EventLogger(e.ToString());
                }
                catch (NoListException e)
                {
                    Display("\n\t The Vending Machine is empty ! ", ConsoleColor.Red);
                    log.Error(e + "\n");
                    eventWriter.EventLogger(e.ToString());
                }
                catch (CancelledPaymentException e)
                {
                    Display("\n\t The Payment was CANCELLED ", ConsoleColor.Red);
                    log.Error(e + "\n");
                    eventWriter.EventLogger(e.ToString());
                }
                catch (TooMuchMoneyException e)
                {
                    Display("\n\t YOU ARE TOO RICH , GO BUY AN ISLAND OR SOMETHING ", ConsoleColor.Yellow);
                    log.Error(e + "\n");
                    eventWriter.EventLogger(e.ToString());
                }
            }
        }

        private List<ICommand> GetExecutableUseCases()
        {
            List<ICommand> executableUseCases = new List<ICommand>();

            foreach (ICommand useCase in useCases)
            {
                if (useCase.CanExecute)
                    executableUseCases.Add(useCase);
            }
            return executableUseCases;
        }
    }
}