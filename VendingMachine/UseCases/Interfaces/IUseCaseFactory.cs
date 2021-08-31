
namespace iQuest.VendingMachine.UseCases.Interfaces
{
    internal interface IUseCaseFactory
    {
        public T Create<T>() where T : IUseCase;
    }
}
