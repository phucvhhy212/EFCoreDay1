namespace Domain
{
    public class ProjectEmployee
    {
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
        public bool Enable { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
