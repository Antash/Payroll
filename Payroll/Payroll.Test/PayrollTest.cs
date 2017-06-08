using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll.Interfaces;
using Payroll.Locations;
using System;
using System.Linq;

namespace Payroll.Test
{
    [TestClass]
    public class PayrollTest
    {
        private readonly IEmployeeFactory employeeFactory = new EmployeeFactory();
        private readonly ISalaryAccount salaryAccount = new SalaryAccount();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Hourly rate is not positive.")]
        public void TestSalaryGross()
        {
            var employee1 = employeeFactory.CreateEmployee("Ireland", 40, 10);
            Assert.AreEqual(400, salaryAccount.GetGrossSalary(employee1));

            var employee2 = employeeFactory.CreateEmployee("Ireland", 35, 20.4m);
            Assert.AreEqual(714, salaryAccount.GetGrossSalary(employee2));

            var employee3 = employeeFactory.CreateEmployee("Ireland", 10, 0);
        }

        [TestMethod]
        public void TestDeductionsIreland()
        {
            var ireland = new Ireland();
            Assert.AreEqual(3, ireland.Deductions.Count());

            var incomeTax = ireland.Deductions.SingleOrDefault(d => d.Description == "Income Tax");
            Assert.IsNotNull(incomeTax);
            Assert.AreEqual(125, incomeTax.Calculate(500));
            Assert.AreEqual(190, incomeTax.Calculate(700));

            var universalSocialCharge = ireland.Deductions.SingleOrDefault(d => d.Description == "Universal Social Charge");
            Assert.IsNotNull(universalSocialCharge);
            Assert.AreEqual(31.5m, universalSocialCharge.Calculate(450));
            Assert.AreEqual(43, universalSocialCharge.Calculate(600));

            var pension = ireland.Deductions.SingleOrDefault(d => d.Description == "Pension");
            Assert.IsNotNull(pension);
            Assert.AreEqual(16, pension.Calculate(400));
            Assert.AreEqual(20, pension.Calculate(500));
        }
    }
}
