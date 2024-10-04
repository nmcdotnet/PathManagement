using System.ComponentModel.DataAnnotations;

namespace PathManagement.Models.Domain
{
    public class GroupPathModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public List<PathModel> Paths { get; set; } = new();
    }
}
