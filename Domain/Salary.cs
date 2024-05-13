using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Salary
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalaryAmount { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
