using System.ComponentModel.DataAnnotations;

namespace HomeLibrary.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Nazwa uzytkownika")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}