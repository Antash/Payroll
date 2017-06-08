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
        private readonly ISalaryAccount salaryAccount = new SalaryAccount(new ILocation[] {
            new Italy(),
            new Germany(),
            new Ireland()
        });

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Hourly rate is not positive.")]
        public void TestSalaryGross()
        {
            var employee1 = employeeFactory.CreateEmployee("Ireland", 40, 10);
            Assert.AreEqual(400, salaryAccount.GetSalaryGross(employee1));

            var employee2 = employeeFactory.CreateEmployee("Ireland", 35, 20.4m);
            Assert.AreEqual(714, salaryAccount.GetSalaryGross(employee2));

            var employee3 = employeeFactory.CreateEmployee("Ireland", 10, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Location is not valid.")]
        public void TestSalaryNet()
        {
            var employee1 = employeeFactory.CreateEmployee("Ireland", 40, 10);
            Assert.AreEqual(400 - 400 * 0.25m - 400 * 0.07m - 400 * 0.04m, 
                salaryAccount.GetSalaryNet(employee1));

            var employee2 = employeeFactory.CreateEmployee("Ireland", 40, 20);
            Assert.AreEqual(800 - 600 * 0.25m - 200 * 0.4m - 500 * 0.07m - 300 * 0.08m - 800 * 0.04m, 
                salaryAccount.GetSalaryNet(employee2));

            var employee = employeeFactory.CreateEmployee("Island", 40, 10);
            salaryAccount.GetSalaryNet(employee);
        }

        [TestMethod]
        public void TestDeductionsIreland()
        {
            var ireland = new Ireland();
            Assert.AreEqual("Ireland", ireland.Name);
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

        [TestMethod]
        public void TestDeductionsItaly()
        {
            var italy = new Italy();
            Assert.AreEqual("Italy", italy.Name);
            Assert.AreEqual(2, italy.Deductions.Count());

            var incomeTax = italy.Deductions.SingleOrDefault(d => d.Description == "Income Tax");
            Assert.IsNotNull(incomeTax);
            Assert.AreEqual(125, incomeTax.Calculate(500));
            Assert.AreEqual(175, incomeTax.Calculate(700));

            var inps = italy.Deductions.SingleOrDefault(d => d.Description == "INPS");
            Assert.IsNotNull(inps);
            Assert.AreEqual(36, inps.Calculate(400));
            Assert.AreEqual(64.4m, inps.Calculate(700));
            Assert.AreEqual(95, inps.Calculate(1000));
            Assert.AreEqual(99.75m, inps.Calculate(1050));
        }

        [TestMethod]
        public void TestDeductionsGermany()
        {
            var germany = new Germany();
            Assert.AreEqual("Germany", germany.Name);
            Assert.AreEqual(2, germany.Deductions.Count());

            var incomeTax = germany.Deductions.SingleOrDefault(d => d.Description == "Income Tax");
            Assert.IsNotNull(incomeTax);
            Assert.AreEqual(100, incomeTax.Calculate(400));
            Assert.AreEqual(196, incomeTax.Calculate(700));

            var pension = germany.Deductions.SingleOrDefault(d => d.Description == "Pension");
            Assert.IsNotNull(pension);
            Assert.AreEqual(8, pension.Calculate(400));
            Assert.AreEqual(14, pension.Calculate(700));
        }
    }
}