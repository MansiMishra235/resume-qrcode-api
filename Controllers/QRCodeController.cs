using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace ResumeQRCodeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QRCodeController : ControllerBase
    {
        [HttpGet("generate")]
        public IActionResult Generate()
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode("https://mansi-portfolio-b12c2.web.app", QRCodeGenerator.ECCLevel.Q);

            var qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeImage = qrCode.GetGraphic(20);

            return File(qrCodeImage, "image/png");
        }
    }
}
