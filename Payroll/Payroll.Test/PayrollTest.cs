using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll.Interfaces;

namespace Payroll.Test
{
    [TestClass]
    public class PayrollTest
    {
        private readonly IEmployeeFactory employeeFactory = new EmployeeFactory();
        private readonly ISalaryAccount salaryAccount = new SalaryAccount();

        [TestMethod]
        public void TestSalaryGross()
        {
            var employee1 = employeeFactory.CreateEmployee("Ireland", 40, 10);
            Assert.AreEqual(400, salaryAccount.GetGrossSalary(employee1));

            var employee2 = employeeFactory.CreateEmployee("Ireland", 35, 20.4m);
            Assert.AreEqual(714, salaryAccount.GetGrossSalary(employee2));
        }
    }
}
