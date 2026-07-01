using System.ComponentModel.DataAnnotations;

namespace taskManagementCrud.Models.viewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
