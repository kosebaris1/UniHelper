using System.ComponentModel.DataAnnotations;

namespace UniWebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SelectedUniversity { get; set; }

        [Required]
        public string SelectedDepartment { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Öğrenci belgesi yüklenmelidir.")]
        [Display(Name = "Öğrenci Belgesi")]
        public IFormFile StudentDocument { get; set; }

        public bool IsEmailTaken { get; set; }

        public List<string> Universities { get; set; }
        public List<string> Departments { get; set; }
    }
}
