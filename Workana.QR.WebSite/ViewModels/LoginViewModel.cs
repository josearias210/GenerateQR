using System.ComponentModel.DataAnnotations;

namespace Workana.QR.WebSite.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage ="Debe ingresar el correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar la contraseña")]
        public string Password { get; set; }
    }
}
