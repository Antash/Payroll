using Payroll.Interfaces;

namespace Payroll
{
    public class Employee : IEmployee
    {
        public Employee(string location, uint hoursWorked, decimal hourlyRate)
        {
            Location = location;
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

        public string Location
        {
            get; protected set;
        }
    }
}
