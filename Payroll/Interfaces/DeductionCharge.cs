namespace Payroll.Interfaces
{
    public struct DeductionCharge
    {
        public DeductionCharge(string description, decimal amount)
        {
            Description = description;
            Amount = amount;
        }

        public string Description { get; private set; }

        public decimal Amount { get; private set; }
    }
}
