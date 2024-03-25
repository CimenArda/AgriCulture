using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adınızı Giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mail Adresi Giriniz.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre  Giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreyi Doğrulayınız.")]
        [Compare("Password",ErrorMessage ="şifre uyumlu değil kontrol edin.")]
        public string PasswordConfirm { get; set; }



    }
}
