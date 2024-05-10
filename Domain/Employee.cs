namespace Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinedDate { get; set; }
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
