using Domain;

namespace Application.IServices
{
    public interface IDepartmentService:IGenericService<Department>
    {
        void Update(Guid id, Department department);
    }
}
