using Microsoft.AspNetCore.Mvc;
using QRCoder;
using QRCoder.SkiaSharp; // ✅ Using the file you just added
using SkiaSharp;
using System.IO;

namespace ResumeQRCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        [HttpGet("generate")]
        public IActionResult Generate()
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode("https://mansi-portfolio-b12c2.web.app", QRCodeGenerator.ECCLevel.Q);
            var qrCode = new SkiaSharpQRCode(qrCodeData);

            using var image = qrCode.GetGraphic(20);
            using var ms = new MemoryStream();
            image.Encode(SKEncodedImageFormat.Png, 100).SaveTo(ms);

            return File(ms.ToArray(), "image/png");
        }
    }
}

