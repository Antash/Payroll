using System;

namespace Payroll.Interfaces
{
    public interface IDeduction
    {
        string Description { get; }
        Func<decimal, decimal> Calculate { get; } 
    }
}
