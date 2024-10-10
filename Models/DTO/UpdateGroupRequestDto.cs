using System.ComponentModel.DataAnnotations;

namespace PathManagement.Models.DTO
{
    public class UpdateGroupRequestDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
