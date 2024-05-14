namespace Domain
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime JoinedDate { get; set; }
        public Guid? DepartmentId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual Department? Department { get; set; }
        public virtual ICollection<ProjectEmployee>? ProjectEmployees { get; set; }
    }
}
