using System.ComponentModel.DataAnnotations;

namespace taskManagementCrud.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Surname { get; set; } = null!;

        [Required]
        public string Role { get; set; } = null!; // "Admin" or "User"
    }
}
