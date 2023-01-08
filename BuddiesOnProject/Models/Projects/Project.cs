using BuddiesOnProject.Models.Employees;
using BuddiesOnProject.Models.Periods;

namespace BuddiesOnProject.Models.Projects
{
    internal class Project
    {
        public long ProjectId { get; set; }

        public IList<Employee> Employees { get; set; }

        public Project()
        {
            Employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        private IList<Employee> GetTeam()
        {
            return Employees;
        }

        public LongestTeamPeriod GetLongestElapsedPeriod()
        {
            var team = GetTeam();
            var maxDurationInDays = 0;
            var employeesWorkedLongest = new List<Employee>();
            var employeesWokedMax = new LongestTeamPeriod();

            if (team.Count >= 2)
            {
                for (var i = 0; i < team.Count; i++)
                {
                    for (var j = i + 1; j < team.Count; j++)
                    {
                        if (team[i].EmployeeId != team[j].EmployeeId)
                        {
                            var employeeStartDate = team[i].PeriodWorked.DateFrom;
                            var employeeEndDate = team[i].PeriodWorked.DateTo != null ? team[i].PeriodWorked.DateTo : DateTime.Now;
                            var otherEmployeeStartDate = team[j].PeriodWorked.DateFrom;
                            var otherEmployeeEndDate = team[j].PeriodWorked.DateTo != null ? team[j].PeriodWorked.DateTo : DateTime.Now;
                            var overlapDuration = 0;

                            var startOfoverlap = employeeStartDate > otherEmployeeStartDate ? employeeStartDate : otherEmployeeStartDate;
                            var endOfOverLap = employeeEndDate < otherEmployeeEndDate ? employeeEndDate : otherEmployeeEndDate;

                            if (startOfoverlap < endOfOverLap)
                            {
                                overlapDuration = ((TimeSpan)(endOfOverLap - startOfoverlap)).Days;

                                if (overlapDuration > maxDurationInDays)
                                {
                                    employeesWokedMax.ProjectId = ProjectId;
                                    employeesWokedMax.Employees.Clear();
                                    employeesWokedMax.Employees.Add(team[i]);
                                    employeesWokedMax.Employees.Add(team[j]);
                                }
                            }
                        }
                    }
                }
            }

            return employeesWokedMax;
        }
    }
}
