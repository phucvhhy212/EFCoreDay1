using Application.IServices;
using Domain;
using Microsoft.Extensions.Logging;
using ApplicationDbContext = Infrastructure.ApplicationDbContext;

namespace Application.Services
{
    public class DepartmentService : GenericService<Department>, IDepartmentService
    {
        public DepartmentService(ILogger<GenericService<Department>> logger, ApplicationDbContext dbContext) : base(logger, dbContext)
        {
        }

        public void Update(Guid id, Department department)
        {
            var findDepartment = dbContext.Departments.Find(id);
            if (findDepartment != null)
            {
                findDepartment.Name = department.Name;
            }
            else
            {
                throw new Exception("Cannot find department to update");
            }
            dbContext.Departments.Update(findDepartment);
            dbContext.SaveChanges();
        }

        
    }
}
