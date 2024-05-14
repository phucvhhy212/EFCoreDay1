using Application.IServices;
using Domain;
using Microsoft.Extensions.Logging;
using ApplicationDbContext = Infrastructure.ApplicationDbContext;

namespace Application.Services
{
    public class ProjectService: GenericService<Project>, IProjectService
    {
        public ProjectService(ILogger<GenericService<Project>> logger, ApplicationDbContext dbContext) : base(logger, dbContext)
        {
        }

        public void Update(Guid id, Project project)
        {
            var findProject = dbContext.Projects.Find(id);
            if (findProject != null)
            {
                findProject.Name = project.Name;
            }
            else
            {
                throw new Exception($"Cannot find any project with id = {id} to update");
            }
            Update(findProject);
        }
    }
}
