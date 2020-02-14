using QRCoder;
using System.Drawing;

namespace Workana.QR.WebSite.Services
{
    public static class QRService
    {
        public static string GenerateQRCodeByUrl(string payload)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new Base64QRCode(qrCodeData);
            var imgType = Base64QRCode.ImageType.Jpeg;

            string qrCodeImageAsBase64 = qrCode.GetGraphic(50,
                       Color.Black,
                       Color.White,
                       true,
                       imgType);

            return qrCodeImageAsBase64;
        }

    }
}
