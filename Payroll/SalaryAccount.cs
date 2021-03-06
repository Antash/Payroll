﻿using Payroll.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Payroll
{
    public class SalaryAccount : ISalaryAccount
    {
        public IEnumerable<DeductionCharge> GetDeductionsCharged(IEmployee employee)
        {
            var gross = GetSalaryGross(employee);
            return employee.Location.Deductions.Select(d => new DeductionCharge(d.Description, d.Calculate(gross)));
        }

        public decimal GetSalaryGross(IEmployee employee)
        {
            return employee.HourlyRate * employee.HoursWorked;
        }

        public decimal GetSalaryNet(IEmployee employee)
        {
            return GetSalaryGross(employee) - GetDeductionsCharged(employee).Sum(d => d.Amount);
        }
    }
}
