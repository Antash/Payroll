namespace Payroll.Interfaces
{
    public interface IEmployeeFactory
    {
        IEmployee CreateEmployee(string location, uint workedHours, decimal hourlyRate);
    }
}
