namespace Application.Dtos
{
    public class EmployeeProjectResponse
    {
        public Guid EmployeeId { get; set; }
        public Guid? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string EmployeeName { get; set; }
    }
}
