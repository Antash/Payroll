using Payroll.Interfaces;
using Payroll.Locations;
using Payroll.UI;
using System;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeFactory employeeFactory = new EmployeeFactory(new ILocation[] {
                new Italy(),
                new Germany(),
                new Ireland()
            });
            IEmployeeCreator creator = new EmployeeCreator(employeeFactory);
            ISalaryAccount salaryAccount = new SalaryAccount();
            ISalaryDetailsPrinter printer = new SalaryDetailsPrinter(salaryAccount);

            var employee = creator.GetEmployee();
            printer.PrintSalaryDetails(employee);

            Console.ReadKey();
        }
    }
}
