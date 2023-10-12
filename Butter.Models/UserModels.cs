using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Butter.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required]
        public string NickName { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[@#$%^&+=!])(?!.*\\s).{8,}$", ErrorMessage ="Votre mot de passe")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Vos mots de passe ne correspondent pas!")]
        public string RePassword { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Date)] 
        //remarque ajouter contrainte date +de 18 ans
        public DateTime BirthDate { get; set; }
        [Required]
        public string Town { get; set; }

        public string Genre { get; set; }
    }
}