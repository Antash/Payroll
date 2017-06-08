using Payroll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Payroll
{
    public class EmployeeFactory : IEmployeeFactory
    {
        private List<ILocation> locationList = new List<ILocation>();

        public EmployeeFactory(IEnumerable<ILocation> locations)
        {
            locationList.AddRange(locations);
        }

        public IEmployee CreateEmployee(string locationName, uint hoursWorked, decimal hourlyRate)
        {
            if (hourlyRate <= 0)
            {
                throw new ArgumentException("Employee hourly rate should be positive.");
            }
            var location = locationList.SingleOrDefault(l => l.Name == locationName);
            if (location == null)
            {
                throw new ArgumentException("Employee location is not valid.");
            }
            return new Employee(location, hoursWorked, hourlyRate);
        }
    }
}
