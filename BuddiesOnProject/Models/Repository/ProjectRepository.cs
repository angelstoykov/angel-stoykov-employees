using BuddiesOnProject.Models.Projects;

namespace BuddiesOnProject.Models.Repository
{
    internal class ProjectRepository
    {
        public IList<Project> Projects { get; set; }

        public ProjectRepository()
        {
            Projects = new List<Project>();
        }

        public void AddProject(Project project)
        {
            if (!IsProjectExist(project.ProjectId))
            {
                Projects.Add(project);
            }
        }

        public bool IsProjectExist(long projectId)
        {
            return Projects.Any(p => p.ProjectId == projectId);
        }
    }
}
