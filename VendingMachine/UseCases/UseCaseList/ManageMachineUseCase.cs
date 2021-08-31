using System;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;
using DataAccess.Repositories.Interfaces;
using System.Linq;
using System.Runtime.CompilerServices;

namespace iQuest.VendingMachine.UseCases.UseCaseList
{
    internal class ManageMachineUseCase : IUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IManageMachineView manageMachineView;
        private readonly IProductRepository productRepo;

        public ManageMachineUseCase(IManageMachineView manageMachineView, IProductRepository productRepo)
        {
            this.manageMachineView = manageMachineView ?? throw new ArgumentNullException(nameof(manageMachineView));
            this.productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
        }

        public void Execute()
        {
            int option = manageMachineView.AskOption();

            switch (option)
            {
                case 1:
                    {
                        productRepo.AddNewProductType(manageMachineView.AskForNewName(), manageMachineView.AskForNewStock(), manageMachineView.AskForNewPrice());
                        break;
                    }
                case 2:
                    {
                        int id = manageMachineView.RequestId();
                        productRepo.IsIdValid(id);
                        string name = productRepo.GetById(id).Name;
                        productRepo.DeleteProductType(id);
                        manageMachineView.ShowDeleteMessage(id, name);
                        break;
                    }
                case 3:
                    {
                        int id = manageMachineView.RequestId();
                        productRepo.IsIdValid(id);
                        productRepo.ChangeProductName(id, manageMachineView.AskForNewName());
                        break;
                    }
                case 4:
                    {
                        int id = manageMachineView.RequestId();
                        productRepo.IsIdValid(id);
                        productRepo.ChangeProductStock(id, manageMachineView.AskForNewStock());
                        break;
                    }
                case 5:
                    {
                        int id = manageMachineView.RequestId();
                        productRepo.IsIdValid(id);
                        productRepo.ChangeProductPrice(id, manageMachineView.AskForNewPrice());
                        break;
                    }

            }
        }
    }
}
