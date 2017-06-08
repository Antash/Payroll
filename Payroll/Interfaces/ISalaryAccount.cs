using System.Collections.Generic;

namespace Payroll.Interfaces
{
    public interface ISalaryAccount
    {
        decimal GetSalaryGross(IEmployee employee);
        decimal GetSalaryNet(IEmployee employee);
        IEnumerable<DeductionCharge> GetDeductionsCharged(IEmployee employee);
    }
}
