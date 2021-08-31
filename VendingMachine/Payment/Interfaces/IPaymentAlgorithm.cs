namespace iQuest.VendingMachine.Payment.Interfaces
{
    internal interface IPaymentAlgorithm
    {
        public string Name { get; }
        void Run(float price, string name);
    }
}
