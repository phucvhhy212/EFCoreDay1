using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class DepartmentRequest
    {
        [Required]
        [MaxLength(40,ErrorMessage = "Max length for department name is 40")]
        public string Name { get; set; }
    }
}
