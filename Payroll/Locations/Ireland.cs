using Payroll.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Payroll.Locations
{
    [Export(typeof(ILocation))]
    public class Ireland : ILocation
    {
        private static readonly IList<IDeduction> deductions = new List<IDeduction>();

        static Ireland()
        {
            deductions.Add(new Deduction("Income Tax", 
                d => d <= 600 ? d * 0.25m : 150 + (d - 600) * 0.4m));
            deductions.Add(new Deduction("Universal Social Charge", 
                d => d <= 500 ? d * 0.07m : 35 + (d - 500) * 0.08m));
            deductions.Add(new Deduction("Pension",
                d => d * 0.04m));
        }

        public IEnumerable<IDeduction> Deductions
        {
            get { return deductions; }
        }

        public string Name
        {
            get { return "Ireland"; }
        }
    }
}
