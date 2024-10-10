using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PathManagement.Models.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string Skin { get; set; } = null!;
        public bool Status { get; set; }
        public string Note { get; set; } = null!;
    }
}
