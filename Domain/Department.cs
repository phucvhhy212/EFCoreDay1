namespace Domain
{
    public class Department
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
