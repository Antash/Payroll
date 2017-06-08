using Payroll.Interfaces;
using System;

namespace Payroll.UI
{
    public class EmployeeCreator : IEmployeeCreator
    {
        IEmployeeFactory employeeFactory = new EmployeeFactory();

        public IEmployee GetEmployee()
        {
            var hoursWorked = PromptHoursWorked();
            var hourlyRate = PromptHourlyRate();
            var location = PromptLocation();
            return employeeFactory.CreateEmployee(location, hoursWorked, hourlyRate);
        }

        private string PromptLocation()
        {
            Console.Write("Please enter the employee’s location: ");
            return Console.ReadLine();
        }

        private uint PromptHoursWorked()
        {
            uint hoursWorked;
            bool inputError = false;
            do
            {
                var tip = inputError ? " (positive integer number)" : string.Empty;
                Console.Write($"Please enter the hours worked{tip}: ");
                var input = Console.ReadLine();
                inputError = !uint.TryParse(input, out hoursWorked);
            } while (inputError);

            return hoursWorked;
        }

        private decimal PromptHourlyRate()
        {
            decimal hourlyRate;
            bool inputError = false;
            do
            {
                var tip = inputError ? " (positive decimal number)" : string.Empty;
                Console.Write($"Please enter the hourly rate{tip}: ");
                var input = Console.ReadLine();
                inputError = !decimal.TryParse(input, out hourlyRate);
                if (!inputError)
                {
                    inputError = hourlyRate <= 0;
                }
            } while (inputError);

            return hourlyRate;
        }
    }
}