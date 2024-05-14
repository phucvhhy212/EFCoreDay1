using Domain;

namespace Application.IServices
{
    public interface IProjectService:IGenericService<Project>
    {
        void Update(Guid id, Project project);
    }
}
