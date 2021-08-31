using Autofac;
using iQuest.VendingMachine.UseCases.Interfaces;

namespace iQuest.VendingMachine.UseCases
{
    internal class UseCaseFactory : IUseCaseFactory
    {
        private readonly IComponentContext context;

        public UseCaseFactory(IComponentContext context)
        {
            this.context = context;
        }

        public T Create<T>() where T : IUseCase
        {
            return context.Resolve<T>();
        }
    }
}