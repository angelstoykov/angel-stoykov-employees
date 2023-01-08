using BuddiesOnProject.Common;
using BuddiesOnProject.Core.Contracts;
using BuddiesOnProject.IO;
using BuddiesOnProject.IO.Contracts;
using BuddiesOnProject.Models.Employees;
using BuddiesOnProject.Models.Periods;
using BuddiesOnProject.Models.Projects;
using BuddiesOnProject.Models.Repository;
using BuddiesOnProject.Models.Utils;
using System.Text;

namespace BuddiesOnProject.Core
{
    internal class Engine : IEngine
    {
        char[] charsToTrim = { ',', '.', ' ' };

        private IWriter writer;
        private ProjectRepository projectRepo;

        public Engine()
        {
            this.writer = new Writer();
            this.projectRepo = new ProjectRepository();
        }

        public void Run()
        {
            var path = Path.Combine(VisualStudioProvider.TryGetSolutionDirectoryInfo().FullName, "data.csv");

            var emloyees = new List<Employee>();

            using (var reader = new StreamReader(path))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (!string.IsNullOrEmpty(line) || !string.IsNullOrWhiteSpace(line))
                    {
                        var tokens = line.Split(", ").ToList();

                        if (tokens.Count == Constants.TOKENS_COUNT)
                        {
                            DateTime.TryParse(tokens[2], out var dateFrom);

                            var employee = new Employee
                            {
                                EmployeeId = long.Parse(tokens[0]),
                                ProjectId = long.Parse(tokens[1]),
                                PeriodWorked = new PeriodWorked
                                {
                                    DateFrom = dateFrom,
                                    DateTo = DateTime.TryParse(tokens[3], out var dateTo) ? dateTo : null
                                }
                            };

                            emloyees.Add(employee);
                        }
                    }
                }
            }

            foreach (var employee in emloyees)
            {
                if (!projectRepo.IsProjectExist(employee.ProjectId))
                {
                    var project = new Project
                    {
                        ProjectId = employee.ProjectId
                    };

                    project.AddEmployee(employee);
                    projectRepo.AddProject(project);
                }
                else
                {
                    var proj = projectRepo.Projects.FirstOrDefault(p => p.ProjectId == employee.ProjectId);
                    if (proj != null)
                    {
                        proj.AddEmployee(employee);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var project in projectRepo.Projects)
            {
                var budies = project.GetLongestElapsedPeriod();

                if (budies.Employees != null
                    && budies.Employees.Count > 0)
                {
                    foreach (var buddy in budies.Employees)
                    {
                        sb.Append($"{buddy.EmployeeId}, ");
                    }

                    sb.Append($"{budies.ProjectId}, ");
                }
            }

            writer.WriteLine(sb.ToString().TrimEnd(charsToTrim));
        }
    }
}
