using Domain;

namespace Application.Dtos
{
    public class EmployeeRequest
    {
        public string Name { get; set; }
        public DateTime JoinedDate { get; set; }
        public Guid? DepartmentId { get; set; }
        public ICollection<Guid>? Projects { get; set; }
    }
}
