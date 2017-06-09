using Payroll.UI;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace Payroll
{
    internal class App
    {
        [Import(typeof(IEmployeeCreator))]
        internal IEmployeeCreator EmployeeCreator { get; set; }

        [Import(typeof(ISalaryDetailsPrinter))]
        internal ISalaryDetailsPrinter SalaryPrinter { get; set; }

        public void Compose()
        {
            try
            {
                var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Run()
        {
            var employee = EmployeeCreator.GetEmployee();
            SalaryPrinter.PrintSalaryDetails(employee);

            Console.ReadKey();
        }
    }
}
