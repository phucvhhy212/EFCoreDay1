using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class SalaryRequest
    {
        public Guid? EmployeeId { get; set; }
        [Range(0,100000)]
        public decimal SalaryAmount { get; set; }
    }
}
