using Payroll.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Payroll
{
    [Export(typeof(IEmployeeFactory))]
    public class EmployeeFactory : IEmployeeFactory
    {
        [ImportMany(typeof(ILocation))]
        internal List<ILocation> LocationList { get; set; }

        public IEmployee CreateEmployee(string locationName, uint hoursWorked, decimal hourlyRate)
        {
            if (hourlyRate <= 0)
            {
                throw new ArgumentException("Employee hourly rate should be positive.");
            }
            var location = LocationList.SingleOrDefault(l => l.Name == locationName);
            if (location == null)
            {
                throw new ArgumentException("Employee location is not valid.");
            }
            return new Employee(location, hoursWorked, hourlyRate);
        }
    }
}
