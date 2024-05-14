using Domain;

namespace Application.Dtos
{
    public class EmployeeDepartmentResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinedDate { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
