using Payroll.Interfaces;
using System;
using System.Text;

namespace Payroll.UI
{
    public class SalaryDetailsPrinter : ISalaryDetailsPrinter
    {
        private ISalaryAccount salaryAccount;

        public SalaryDetailsPrinter(ISalaryAccount salaryAccount)
        {
            this.salaryAccount = salaryAccount;
        }

        public void PrintSalaryDetails(IEmployee employee)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Employee location: {employee.LocationName}\n");
            Console.WriteLine($"Gross Amount: €{salaryAccount.GetSalaryGross(employee)}\n");
            Console.WriteLine("Less deductions\n");

            foreach (var deduction in salaryAccount.GetDeductionsCharged(employee))
            {
                Console.WriteLine($"{deduction.Description}: €{deduction.Amount}");
            }

            Console.WriteLine($"Net Amount: €{salaryAccount.GetSalaryNet(employee)}");
        }
    }
}
