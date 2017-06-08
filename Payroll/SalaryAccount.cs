using Payroll.Interfaces;
using System;

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
