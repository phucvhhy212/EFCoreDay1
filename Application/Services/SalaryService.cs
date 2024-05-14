using Application.Dtos;
using Application.IServices;
using Domain;
using Microsoft.Extensions.Logging;
using ApplicationDbContext = Infrastructure.ApplicationDbContext;

namespace Application.Services
{
    public class SalaryService:GenericService<Salary>,ISalaryService
    {
        public SalaryService(ILogger<GenericService<Salary>> logger, ApplicationDbContext dbContext) : base(logger, dbContext)
        {
        }

        public void Add(SalaryRequest salaryRequest)
        {
            if (!dbContext.Employees.Any(x => x.Id == salaryRequest.EmployeeId))
            {
                throw new Exception("Employee not exist");
            }

            Salary s = new Salary
            {
                EmployeeId = salaryRequest.EmployeeId,
                SalaryAmount = salaryRequest.SalaryAmount
            };
            dbContext.Salaries.Add(s);
            dbContext.SaveChanges();
        }

        public void Update(Guid id, SalaryRequest salaryRequest)
        {
            var findSalary = dbContext.Salaries.Find(id);
            if (findSalary == null)
            {
                throw new Exception("Salary not exist");
            }
            if (!dbContext.Employees.Any(x => x.Id == salaryRequest.EmployeeId))
            {
                throw new Exception("Employee not exist");
            }
            findSalary.EmployeeId = salaryRequest.EmployeeId;
            findSalary.SalaryAmount = salaryRequest.SalaryAmount;
            Update(findSalary);
        }
    }
}
