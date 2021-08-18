using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QR_API.DTOs;
using QR_API.Helpers;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace QR_API.Controllers
{
    public class HomeController : BaseController
    {
        [HttpPost]
        public IActionResult CreateText(TextDto textInput)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textInput.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(textInput.Size);
            //Uncomment to load optional image in center of QR code
            //Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile("C:\\myimage.png"));
            var file = ImageToBytes.ImageToByteArray(qrCodeImage);
            return File(file, textInput.Output);
        }


    }
}
