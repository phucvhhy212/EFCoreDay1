using Application.Dtos;
using Domain;

namespace Application.IServices
{
    public interface IEmployeeService:IGenericService<Employee>
    {
        void Add(EmployeeRequest employeeRequest);
        void Update(Guid id, EmployeeRequest employeeRequest);
        IEnumerable<Employee> GetEmployeeWithDepartmentName();
        IEnumerable<EmployeeProjectResponse> GetEmployeeWithProjects();
        IEnumerable<CustomEmployeeResponse> GetEmployeeBySalaryAndJoinedDate();
    }
}
