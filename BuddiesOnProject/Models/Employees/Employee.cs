using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuddiesOnProject.Models.Periods;

namespace BuddiesOnProject.Models.Employees
{
    internal class Employee
    {
        public long EmployeeId { get; set; }

        public long ProjectId { get; set; }

        public PeriodWorked PeriodWorked { get; set; }
    }
}
