using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PathManagement.Models;

[Index(nameof(Username), IsUnique = true)]
public partial class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(50)]
    public string Username { get; set; } = null!;

    [MaxLength(50)]
    public string Password { get; set; } = null!;

    [MaxLength(200)]
    public string FullName { get; set; } = null!;

    [MaxLength(200)]
    public string Department { get; set; } = null!;

    [MaxLength(200)]
    public string Skin { get; set; } = null!;

    public bool Status { get; set; }

    [MaxLength(2000)]
    public string Note { get; set; } = null!;
}
