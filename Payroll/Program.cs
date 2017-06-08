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
            IEmployeeCreator creator = new EmployeeCreator(new EmployeeFactory());
            ISalaryAccount salaryAccount = new SalaryAccount(new ILocation[] {
                new Italy(),
                new Germany(),
                new Ireland()
            });
            ISalaryDetailsPrinter printer = new SalaryDetailsPrinter(salaryAccount);

            var employee = creator.GetEmployee();
            printer.PrintSalaryDetails(employee);

            Console.ReadKey();
        }
    }
}
