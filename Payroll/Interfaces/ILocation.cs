using System.Collections.Generic;

namespace Payroll.Interfaces
{
    public interface ILocation
    {
        string Name { get; }
        IEnumerable<IDeduction> Deductions { get; }
    }
}
