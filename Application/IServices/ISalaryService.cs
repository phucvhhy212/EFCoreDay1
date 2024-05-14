using Application.Dtos;
using Domain;

namespace Application.IServices
{
    public interface ISalaryService:IGenericService<Salary>
    {
        void Add(SalaryRequest salaryRequest);
        void Update(Guid id, SalaryRequest salaryRequest);
    }
}
