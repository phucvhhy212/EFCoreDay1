namespace Domain
{
    public class Salary
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal SalaryAmount { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
