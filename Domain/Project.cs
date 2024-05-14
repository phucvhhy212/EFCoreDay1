namespace Domain
{
    public class Project
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<ProjectEmployee>? ProjectEmployees { get; set; }

    }
}
