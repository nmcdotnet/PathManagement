using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PathManagement.Models.Domain
{
    public class PathModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Path { get; set; } // path is required and has a defined maximum length

        public int GroupPathId { get; set; }  // liên kết đến khóa chính của GroupPathModel

        [ForeignKey("GroupPathId")] // specify GroupPathId as a foreign key
        public GroupPathModel? GroupPath { get; set; }
    }
}
