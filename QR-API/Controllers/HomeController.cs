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
using static QRCoder.PayloadGenerator;
using static QRCoder.PayloadGenerator.ContactData;
using static QRCoder.PayloadGenerator.Girocode;

namespace QR_API.Controllers
{
    public class HomeController : BaseController
    {
        [HttpPost("text")]
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

        [HttpPost("bitcoin")]
        public IActionResult CreateBitCoin(BitCoinDto bitCoinDto)
        {
            BitcoinAddress generator = new BitcoinAddress(bitCoinDto.address,bitCoinDto.amount,bitCoinDto.lable,bitCoinDto.Message);
            string payload = generator.ToString();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(bitCoinDto.Size);
            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, bitCoinDto.Output);
        }

        [HttpPost("bookmark")]
        public IActionResult CreateBookMark(BookmarkDto bookmarkDto)
        {
            Bookmark generator = new Bookmark(bookmarkDto.Url, bookmarkDto.Title);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(bookmarkDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, bookmarkDto.Output);
        }

        [HttpPost("calendar")]
        public IActionResult CreateCalendar(CalendarEventDto calendarEventDto)
        {
            CalendarEvent generator = new CalendarEvent(calendarEventDto.Subject, calendarEventDto.Description, calendarEventDto.Location, calendarEventDto.Start, calendarEventDto.End, calendarEventDto.AllDayEvent);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(calendarEventDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, calendarEventDto.Output);
        }

        [HttpPost("contact")]
        public IActionResult CreateContact(ContactDto contactDto)
        {
            ContactData generator = new ContactData(ContactData.ContactOutputType.VCard3, contactDto.FirstName, contactDto.LastName, contactDto.NickName, contactDto.Phone, contactDto.MobilePhone, contactDto.WorkPhone, contactDto.Email, contactDto.BirthDate, contactDto.WebSite, contactDto.street, contactDto.HouseNumber, contactDto.City, contactDto.ZipCode, contactDto.Country, contactDto.Note, contactDto.street,(contactDto.AddressOrder.ToLower() !="reversed")? AddressOrder.Default: AddressOrder.Reversed);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(contactDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, contactDto.Output);
        }

        [HttpPost("location")]
        public IActionResult CreateGeoLocation(GeoLocationDto geoLocationDto)
        {
            Geolocation generator = new Geolocation(geoLocationDto.latitude, geoLocationDto.longitude);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(geoLocationDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, geoLocationDto.Output);
        }

        [HttpPost("girocode")]
        public IActionResult CreateGiroCode(GiroCodeDto giroCodeDto)
        {
            Girocode generator = new Girocode(giroCodeDto.Iban, giroCodeDto.Bic, giroCodeDto.Name, giroCodeDto.Amount, giroCodeDto.RemittanceInformation, TypeOfRemittance.Structured, giroCodeDto.purposeOfCreditTransfer, giroCodeDto.messageToGirocodeUser, GirocodeVersion.Version1);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(giroCodeDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, giroCodeDto.Output);
        }
        [HttpPost("mail")]
        public IActionResult CreateEmail(EmailDto emailDto)
        {
            Mail generator = new Mail(emailDto.MailReceiver, emailDto.Subject, emailDto.Message);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(emailDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, emailDto.Output);
        }
        [HttpPost("mms")]
        public IActionResult CreateMMS(MMSDto mmsDto)
        {
            MMS generator = new MMS(mmsDto.Number, mmsDto.Text);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(mmsDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, mmsDto.Output);
        }
    }
}
