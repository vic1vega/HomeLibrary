using System.ComponentModel.DataAnnotations;

namespace HomeLibrary.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana.")]
        [Display(Name = "Nazwa użytkownika:")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [Display(Name = "Hasło:")]
        [StringLength(20, ErrorMessage = "Hasło powinno mieć od 5 do 20 znaków", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        // [Required(ErrorMessage = "Potwierdzenie hasła jest wymagane.")]
        // [Display(Name = "Powtórz hasło:")]
        // [StringLength(20, ErrorMessage = "Hasło powinno mieć od 5 do 20 znaków", MinimumLength = 5)]
        // [DataType(DataType.Password)]
        // [Compare("Password", ErrorMessage = "Hasła nie są zgodne.")]
        // public string ConfirmPassword { get; set; }
    }
}