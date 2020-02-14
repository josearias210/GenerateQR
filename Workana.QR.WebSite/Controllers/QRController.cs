using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workana.QR.WebSite.Services;
using Workana.QR.WebSite.ViewModels;

namespace Workana.QR.WebSite.Controllers
{
    public class QRController : ControllerBase
    {
        private readonly EmailService emailService;

        public QRController(EmailService emailService)
        {
            this.emailService = emailService;
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductViewModel vm)
        {
            try
            {
                
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }
                
                var message = SecurityService.Encrypt(vm.ToString());
                var qr = QRService.GenerateQRCodeByUrl(message);
                var html = GetContentEmail(qr);

                await emailService.SendQR(vm.Email, "Nuevo QR generado", html);

                SetFlash(FlashMessageType.Success, "El codigo fue enviado al correo");
                return View();
            }
            catch
            {
                SetFlash(FlashMessageType.Danger, "Error: No se generar el codigo QR");
                return View();
            }
        }

        private string GetContentEmail(string qr)
        {
            string html = "<p>Tu QR es:</p>";
            html += "<br />";
            return $"<img src=\"data:image/jpg;base64,{qr}\" height=\"100\" \"/>";
        }
    }
}