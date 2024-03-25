using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Girin")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Girin")]
        public string Password { get; set; }

    }
}
