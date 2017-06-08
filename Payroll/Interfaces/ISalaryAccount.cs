namespace Payroll.Interfaces
{
    public interface ISalaryAccount
    {
        decimal GetGrossSalary(IEmployee employee);
    }
}
