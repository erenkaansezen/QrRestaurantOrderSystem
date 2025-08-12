using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace WebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap qrCodeImage = qrCode.GetGraphic(10))
                {
                    qrCodeImage.Save(ms, ImageFormat.Png);
                    ViewBag.QrCodeImage= "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}
