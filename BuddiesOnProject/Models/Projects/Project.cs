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
                foreach (var employee in team)
                {
                    foreach (var otherEmployee in team)
                    {
                        if (employee.EmployeeId != otherEmployee.EmployeeId)
                        {
                            var employeeStartDate = employee.PeriodWorked.DateFrom;
                            var employeeEndDate = employee.PeriodWorked.DateTo != null ? employee.PeriodWorked.DateTo : DateTime.Now;
                            var otherEmployeeStartDate = otherEmployee.PeriodWorked.DateFrom;
                            var otherEmployeeEndDate = otherEmployee.PeriodWorked.DateTo != null ? otherEmployee.PeriodWorked.DateTo : DateTime.Now;
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
                                    employeesWokedMax.Employees.Add(employee);
                                    employeesWokedMax.Employees.Add(otherEmployee);
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
