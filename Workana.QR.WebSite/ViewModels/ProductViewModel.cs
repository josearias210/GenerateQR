using System.ComponentModel.DataAnnotations;

namespace Workana.QR.WebSite.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Debe ingresar el cpu")]
        public string CpuId { get; set; }

        public string Code { get; set; }

        [Required(ErrorMessage = "Debe ingresar la cantidad")]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Debe ingresar la hora")]
        public string Time { get; set; }

        [EmailAddress(ErrorMessage =  "Correo invalido")]
        [Required(ErrorMessage = "Debe ingresar el correo")]
        public string Email { get; set; }

        public override string ToString()
        {
            Code = "";
            return $"voucher_id={CpuId}|{Code}|{Quantity}|{Date}|{Time}";
        }
    }
}
