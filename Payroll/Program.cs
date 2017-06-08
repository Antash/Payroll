using Payroll.UI;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeCreator creator = new EmployeeCreator();

            var employee = creator.GetEmployee();
        }
    }
}
