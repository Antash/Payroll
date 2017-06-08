namespace Payroll.Interfaces
{
    public interface ISalaryAccount
    {
        decimal GetSalaryGross(IEmployee employee);
        decimal GetSalaryNet(IEmployee employee);
    }
}
