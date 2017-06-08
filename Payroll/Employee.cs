using Payroll.Interfaces;

namespace Payroll
{
    public class Employee : IEmployee
    {
        public Employee(string locationName, uint hoursWorked, decimal hourlyRate)
        {
            LocationName = locationName;
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public decimal HourlyRate
        {
            get; protected set;
        }

        public uint HoursWorked
        {
            get; protected set;
        }

        public string LocationName
        {
            get; protected set;
        }
    }
}
