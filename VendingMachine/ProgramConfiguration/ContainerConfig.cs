using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.UseCases.UseCaseList;
using iQuest.VendingMachine.UseCases.Reports.Services;
using iQuest.VendingMachine.UseCases.Reports.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Views;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.Payment.Interfaces;
using iQuest.VendingMachine.Services.Authentication;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using System.Reflection;
using Autofac;
using System.Configuration;
using VendingMachineDomain;

namespace iQuest.VendingMachine.ProgramConfiguration
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //                  VIEWS
            builder.RegisterType<BuyView>().As<IBuyView>();
            builder.RegisterType<MainView>().As<IMainView>();
            builder.RegisterType<ShelfView>().As<IShelfView>();
            builder.RegisterType<LoginView>().As<ILoginView>();
            builder.RegisterType<CashPaymentView>().As<ICashPaymentView>();
            builder.RegisterType<CardPaymentView>().As<ICardPaymentView>();
            builder.RegisterType<ReportsView>().As<IReportsView>();
            builder.RegisterType<ManageMachineView>().As<IManageMachineView>();

            //                  SERVICES
            builder.RegisterType<UseCaseFactory>().As<IUseCaseFactory>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<PaymentUseCase>().As<IPaymentUseCase>();
            builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<ZippedReportFileStream>().As<IZippedReportFileStream>();
            builder.RegisterType<EventViewerErrorWriter>().As<IEventViewerErrorWriter>();

            if (ConfigurationManager.AppSettings["Format"].Equals("JSON"))
                builder.RegisterType<ReportsSerializerJSON>().As<IReportsSerializer>();

            if (ConfigurationManager.AppSettings["Format"].Equals("XML"))
                builder.RegisterType<ReportsSerializerXML>().As<IReportsSerializer>();

            //                   REPOSITORiES   
            builder.Register(c => new InMemoryRepository()).As<IProductRepository>().SingleInstance();
            builder.Register(c => new LiteDBRepository(@"Filename=D:\Programing\BitBucket\Remote Learning\Homework5\Vending Machine\DataAccess\DB.DB;connection=shared")).As<IProductRepository>().SingleInstance();
            builder.Register(c => new EntityFrameworkRepository(new VendingMachineContext())).As<IProductRepository>().SingleInstance();
            builder.Register(c => new LiteDBRepositorySold(@"Filename=D:\Programing\BitBucket\Remote Learning\Homework5\Vending Machine\DataAccess\DB.DB;connection=shared")).As<ISoldProductRepository>().SingleInstance();
            builder.Register(c => new EntityFrameworkSoldsRepository(new VendingMachineContext())).As<ISoldProductRepository>().SingleInstance();

           

            //                   ASSEMBLYS
            Assembly paymentAlgorithmAssembly = typeof(IPaymentAlgorithm).Assembly;
            builder.RegisterAssemblyTypes(paymentAlgorithmAssembly).As<IPaymentAlgorithm>();
            Assembly useCaseAssembly = typeof(IUseCase).Assembly;
            builder.RegisterAssemblyTypes(useCaseAssembly).As<IUseCase>().AsSelf();
            Assembly commandAssembly = typeof(ICommand).Assembly;
            builder.RegisterAssemblyTypes(commandAssembly).As<ICommand>();

            return builder.Build();
        }
    }
}