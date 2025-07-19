using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace ResumeQRCodeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QRCodeController : ControllerBase
{
    [HttpGet]
public IActionResult GetQRCode()
{
    using var qrGenerator = new QRCodeGenerator();
using var qrCodeData = qrGenerator.CreateQrCode("https://mansi-portfolio-b12c2.web.app/assets/Mansi_Mishra.pdf", QRCodeGenerator.ECCLevel.Q);
    using var qrCode = new QRCode(qrCodeData);
    using var bitmap = qrCode.GetGraphic(20);

    using var stream = new MemoryStream();
    bitmap.Save(stream, ImageFormat.Png);
    stream.Seek(0, SeekOrigin.Begin);

    return File(stream.ToArray(), "image/png");
}

}
