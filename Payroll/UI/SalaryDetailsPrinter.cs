using Payroll.Interfaces;
using System;
using System.ComponentModel.Composition;
using System.Text;

namespace Payroll.UI
{
    [Export(typeof(ISalaryDetailsPrinter))]
    public class SalaryDetailsPrinter : ISalaryDetailsPrinter
    {
        [Import(typeof(ISalaryAccount))]
        internal ISalaryAccount SalaryAccount { get; set; }

        public void PrintSalaryDetails(IEmployee employee)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Employee location: {employee.Location.Name}\n");
            Console.WriteLine($"Gross Amount: €{SalaryAccount.GetSalaryGross(employee)}\n");
            Console.WriteLine("Less deductions\n");

            foreach (var deduction in SalaryAccount.GetDeductionsCharged(employee))
            {
                Console.WriteLine($"{deduction.Description}: €{deduction.Amount}");
            }

            Console.WriteLine($"Net Amount: €{SalaryAccount.GetSalaryNet(employee)}");
        }
    }
}
