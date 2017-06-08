namespace Payroll.Interfaces
{
    public interface IEmployeeFactory
    {
        IEmployee CreateEmployee(string locationName, uint workedHours, decimal hourlyRate);
    }
}
