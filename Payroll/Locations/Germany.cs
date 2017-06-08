using Payroll.Interfaces;
using System.Collections.Generic;

namespace Payroll.Locations
{
    public class Germany : ILocation
    {
        private static readonly IList<IDeduction> deductions = new List<IDeduction>();

        static Germany()
        {
            deductions.Add(new Deduction("Income Tax",
                d => d <= 400 ? d * 0.25m : 100 + (d - 400) * 0.32m));
            deductions.Add(new Deduction("Pension",
                d => d * 0.02m));
        }

        public IEnumerable<IDeduction> Deductions
        {
            get { return deductions; }
        }

        public string Name
        {
            get { return "Germany"; }
        }
    }
}
