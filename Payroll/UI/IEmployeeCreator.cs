using Payroll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.UI
{
    public interface IEmployeeCreator
    {
        IEmployee GetEmployee();
    }
}
