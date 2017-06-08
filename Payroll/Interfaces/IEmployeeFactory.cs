namespace Payroll.Interfaces
{
    public interface IEmployeeFactory
    {
        IEmployee CreateEmployee(string locationName, uint hoursWorked, decimal hourlyRate);
    }
}
