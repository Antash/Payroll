using Payroll.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Payroll
{
    public class SalaryAccount : ISalaryAccount
    {
        private List<ILocation> locationList = new List<ILocation>();

        public SalaryAccount(IEnumerable<ILocation> locations)
        {
            locationList.AddRange(locations);
        }

        public IEnumerable<DeductionCharge> GetDeductionsCharged(IEmployee employee)
        {
            var employeeLocation = locationList.SingleOrDefault(l => l.Name == employee.LocationName);
            if (employeeLocation == null)
            {
                throw new ArgumentException("Employee location is not valid.");
            }
            var gross = GetSalaryGross(employee);
            return employeeLocation.Deductions.Select(d => new DeductionCharge(d.Description, d.Calculate(gross)));
        }

        public decimal GetSalaryGross(IEmployee employee)
        {
            return employee.HourlyRate * employee.HoursWorked;
        }

        public decimal GetSalaryNet(IEmployee employee)
        {
            var employeeLocation = locationList.SingleOrDefault(l => l.Name == employee.LocationName);
            if (employeeLocation == null)
            {
                throw new ArgumentException("Employee location is not valid.");
            }
            var gross = GetSalaryGross(employee);
            return gross - GetDeductionsCharged(employee).Sum(d => d.Amount);
        }
    }
}
