using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuddiesOnProject.Models.Employees;

namespace BuddiesOnProject.Models.Periods
{
    internal class LongestTeamPeriod
    {
        public long ProjectId { get; set; }

        public IList<Employee> Employees { get; set; }

        public LongestTeamPeriod()
        {
            Employees = new List<Employee>();
        }
    }
}
