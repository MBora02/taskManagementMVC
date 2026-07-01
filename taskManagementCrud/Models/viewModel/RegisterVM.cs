using System.ComponentModel.DataAnnotations;

namespace taskManagementCrud.Models.viewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Ad zorunludur.")]
        [Display(Name = "Ad")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Soyad zorunludur.")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Şifre tekrarı zorunludur.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        [Display(Name = "Şifre Tekrarı")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Rol seçimi zorunludur.")]
        [Display(Name = "Rol")]
        public string Role { get; set; } = "User"; // "Admin" or "User"
    }
}
