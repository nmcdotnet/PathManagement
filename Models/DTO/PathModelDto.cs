using PathManagement.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PathManagement.Models.DTO
{
    public class PathModelDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Path { get; set; } // path is required and has a defined maximum length

        public int GroupPathId { get; set; }  // Each Path belongs to a GroupPath
    }
}
