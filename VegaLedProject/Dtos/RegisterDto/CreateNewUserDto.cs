using System.ComponentModel.DataAnnotations;

namespace VegaLedProject.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        
        [Required(ErrorMessage = "Kullanıcı adı alanı doldurulmak zorundadır.")]
        public string UserName { get; set; }
        public string UserType { get; set; }
        [Required(ErrorMessage = "Kullanıcı Şifre alanı doldurulmak zorundadır.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Kullanıcı Şifre alanı doldurulmak zorundadır.")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor lütfen kontrol ediniz.")]
        public string ConfirmPassword { get; set; }
    }
}
