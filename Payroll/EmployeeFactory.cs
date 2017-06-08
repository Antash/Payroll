using Payroll.Interfaces;

namespace Payroll
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public IEmployee CreateEmployee(string location, uint hoursWorked, decimal hourlyRate)
        {
            return new Employee(location, hoursWorked, hourlyRate);
        }
    }
}
