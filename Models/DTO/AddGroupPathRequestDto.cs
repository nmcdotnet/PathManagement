using PathManagement.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace PathManagement.Models.DTO
{
    public class AddGroupPathRequestDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
