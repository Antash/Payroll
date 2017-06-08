using Payroll.Interfaces;

namespace Payroll
{
    public class SalaryAccount : ISalaryAccount
    {
        public decimal GetGrossSalary(IEmployee employee)
        {
            return employee.HourlyRate * employee.HoursWorked;
        }
    }
}
