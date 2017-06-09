using Payroll.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Payroll.Locations
{
    [Export(typeof(ILocation))]
    public class Italy : ILocation
    {
        private static readonly IList<IDeduction> deductions = new List<IDeduction>();

        static Italy()
        {
            deductions.Add(new Deduction("Income Tax",
                d => d * 0.25m));
            deductions.Add(new Deduction("INPS",
                d => d <= 500 ? d * 0.09m : d * (0.09m + (int)((d - 500) / 100) * 0.001m)));
        }

        public IEnumerable<IDeduction> Deductions
        {
            get { return deductions; }
        }

        public string Name
        {
            get { return "Italy"; }
        }
    }
}
