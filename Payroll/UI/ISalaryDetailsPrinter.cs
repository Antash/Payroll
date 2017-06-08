using Payroll.Interfaces;

namespace Payroll.UI
{
    public interface ISalaryDetailsPrinter
    {
        void PrintSalaryDetails(IEmployee employee);
    }
}
