using Payroll.Interfaces;
using System;

namespace Payroll
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public IEmployee CreateEmployee(string location, uint hoursWorked, decimal hourlyRate)
        {
            if (hourlyRate <= 0)
            {
                throw new ArgumentException("Employee hourly rate should be positive.");
            }
            return new Employee(location, hoursWorked, hourlyRate);
        }
    }
}
