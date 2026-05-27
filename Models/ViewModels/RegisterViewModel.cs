using System.ComponentModel.DataAnnotations;

namespace SklepPB.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Address { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić adres email")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić nazwę użytkownika")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Hasła muszą być jednakowe!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
