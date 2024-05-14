using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class ProjectRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
