using Application.Dtos;
using Application.IServices;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ApplicationDbContext = Infrastructure.ApplicationDbContext;

namespace Application.Services
{
    public class EmployeeService : GenericService<Employee>, IEmployeeService
    {
        public EmployeeService(ILogger<GenericService<Employee>> logger, ApplicationDbContext dbContext) : base(logger, dbContext)
        {
        }

        public void Add(EmployeeRequest employeeRequest)
        {
            var findDep = dbContext.Departments.Find(employeeRequest.DepartmentId);
            if (findDep == null)
            {
                throw new Exception("Department not exist");
            }
            if (employeeRequest.Projects != null)
            {
                var findProject = employeeRequest.Projects.All(x => dbContext.Projects.Select(p => p.Id).Contains(x));
                if (!findProject)
                {
                    throw new Exception("Project not exist");
                }
            }
            var id = Guid.NewGuid();
            var employee = new Employee
            {
                Id = id,
                JoinedDate = employeeRequest.JoinedDate,
                Name = employeeRequest.Name,
                DepartmentId = employeeRequest.DepartmentId,

            };
            if (employeeRequest.Projects != null)
            {
                employee.ProjectEmployees = employeeRequest.Projects.Select(x => new ProjectEmployee
                {
                    EmployeeId = id,
                    ProjectId = x
                }).ToList();
            }
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetEmployeeWithDepartmentName()
        {
            return dbContext.Employees.Include(x => x.Department).ToList();
        }

        public IEnumerable<EmployeeProjectResponse> GetEmployeeWithProjects()
        {
            return dbContext.Employees
    .GroupJoin(dbContext.ProjectEmployees,
        employee => employee.Id,
        projectEmployee => projectEmployee.EmployeeId,
        (employee, projectEmployees) => new { employee, projectEmployees })
    .SelectMany(
        employeeGroup => employeeGroup.projectEmployees.DefaultIfEmpty(),
        (employeeGroup, projectEmployee) => new EmployeeProjectResponse
        {
            EmployeeId = employeeGroup.employee.Id,
            EmployeeName = employeeGroup.employee.Name,
            ProjectId = projectEmployee != null ? projectEmployee.ProjectId : (Guid?)null,
            ProjectName = projectEmployee != null && projectEmployee.Project != null ? projectEmployee.Project.Name : null
        })
    .ToList();
        }

        public IEnumerable<CustomEmployeeResponse> GetEmployeeBySalaryAndJoinedDate()
        {
            var result = dbContext.Salaries.Include(x => x.Employee).Where(x =>
                x.SalaryAmount > 100 && x.Employee.JoinedDate > DateTime.Parse("1/1/2024"));
            return result.Select(x => new CustomEmployeeResponse
            {
                Id = x.Employee.Id,
                JoinedDate = x.Employee.JoinedDate,
                Name = x.Employee.Name,
                DepartmentId = x.Employee.DepartmentId,
                SalaryAmount = x.SalaryAmount
            });
        }

        public void Update(Guid id, EmployeeRequest employeeRequest)
        {
            var findEmp = dbContext.Employees.Find(id);
            if (findEmp == null)
            {
                throw new Exception($"Cannot find employee with id = {id} to update");
            }

            var findDep = dbContext.Departments.Find(employeeRequest.DepartmentId);
            if (findDep == null)
            {
                throw new Exception("Department not exist");
            }

            bool findProject = employeeRequest.Projects.All(x => dbContext.Projects.Select(p => p.Id).Contains(x));
            if (!findProject)
            {
                throw new Exception("Project not exist");
            }
            findEmp.Name = employeeRequest.Name;
            findEmp.DepartmentId = employeeRequest.DepartmentId;
            findEmp.JoinedDate = employeeRequest.JoinedDate;
            dbContext.ProjectEmployees.RemoveRange(dbContext.ProjectEmployees.Where(x => x.EmployeeId == id));
            dbContext.ProjectEmployees.AddRange(employeeRequest.Projects.Select(x => new ProjectEmployee
            {
                EmployeeId = id,
                ProjectId = x
            }));
            dbContext.SaveChanges();
        }
    }
}
