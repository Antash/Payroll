using System;
using Payroll.Interfaces;

namespace Payroll
{
    public class Deduction : IDeduction
    {
        public Deduction(string description, Func<decimal, decimal> algorithm)
        {
            Description = description;
            Calculate = algorithm;
        }

        public Func<decimal, decimal> Calculate
        {
            get; protected set;
        }

        public string Description
        {
            get; protected set;
        }
    }
}
