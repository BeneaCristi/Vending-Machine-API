namespace iQuest.VendingMachine.Payment.Services
{
    internal class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PaymentMethod(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
