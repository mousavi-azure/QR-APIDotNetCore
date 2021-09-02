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


        /// <summary>
        /// Use this payload to share Bitcoin/Bitcoin Cash/Litecoin addresses or initiate payments in one of those currencies.
        /// </summary>
        /// <param name="bitCoinDto"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Use this payload, when you want to place a bookmark in the user's default webbrowser.
        /// </summary>
        /// <param name="bookmarkDto"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Use this payload to place an event to the user's calendar application.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="description"></param>
        /// <param name="location"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="allDayEvent"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
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


        /// <summary>
        /// ContactData generator = new ContactData(ContactData.ContactOutputType.VCard3, "John", "Doe");
        /// </summary>
        /// <param name="contactDto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Use this payload type when you want to share a location. You can choose between the geo-format and Google Maps links.
        /// </summary>
        /// <param name="geoLocationDto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Use this payload type if you want to share payment contact information and/or bank transfer data. The Girocode is an European standard and supports SEPA payments.
        /// </summary>
        /// <param name="giroCodeDto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Use it when you want to prepare/compose an email. Once scanned the code opens the default mail client with the given information like receiver, subject and message.
        /// </summary>
        /// <param name="emailDto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Use it when you want to compose a MMS (message). You can choose if you want to prepare the message or just let the QR code open the messaging app with the correct phonenumber.
        /// </summary>
        /// <param name="mmsDto"></param>
        /// <returns></returns>
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


        /// <summary>
        /// This payload opens the user's Monero client/app and prefills its dialog with the given data. Either you pass only the Monero address or you add complete payment/transaction details.
        /// </summary>
        /// <param name="moneroDto"></param>
        /// <returns></returns>
        [HttpPost("monero")]
        public IActionResult Createmonero(MoneroDto moneroDto)
        {
            MoneroTransaction generator = new MoneroTransaction(moneroDto.address, moneroDto.txAmount, moneroDto.txPaymentId,moneroDto.recipientName, moneroDto.txDescription);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(moneroDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, moneroDto.Output);
        }


        /// <summary>
        /// This payload generates a one-time-password QR code which is used for credential-exchange and authentification. You may use it in combination with the Google Authenticator.
        /// </summary>
        /// <param name="moneroDto"></param>
        /// <returns></returns>
        [HttpPost("password")]
        public IActionResult CreateOneTimePassword(PasswordDto passwordDto)
        {
            OneTimePassword generator = new OneTimePassword()
            {
                Secret = passwordDto.Secret,
                Issuer = passwordDto.Issuer,
                Label = passwordDto.Lable,
                Algorithm=passwordDto.Algorithm,
                Type=passwordDto.Type,
                Digits=passwordDto.Digits,
                Counter=passwordDto.Counter,
                Period=passwordDto.Period
            };
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(passwordDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, passwordDto.Output);
        }


        /// <summary>
        /// Use it, when you want to share a phonenumber or when you want to use the QR code as CTA (call-to-action). Once scanned, the code opens the dialer app on the phone.
        /// </summary>
        /// <param name="phoneDto"></param>
        /// <returns></returns>
        [HttpPost("Phone")]
        public IActionResult CreateNumber(PhoneDto phoneDto)
        {
            PhoneNumber generator = new PhoneNumber(phoneDto.Number);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(phoneDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, phoneDto.Output);
        }


        /// <summary>
        /// Use it to share ShadowSocks (Proxy) configurations. When scanned, the QR scanner app should start the ShadowSocks with the given configuration.
        /// </summary>
        /// <param name="Shadow"></param>
        /// <returns></returns>
        [HttpPost("shadow")]
        public IActionResult CreateShadowSocks(ShadowsocksDto shadowsocksDto)
        {
            ShadowSocksConfig generator = new ShadowSocksConfig(shadowsocksDto.hostname, shadowsocksDto.Port, shadowsocksDto.Password, ShadowSocksConfig.Method.Aes256Cb);
            string payload = generator.ToString();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(shadowsocksDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, shadowsocksDto.Output);
        }

        /// <summary>
        /// Use it when you want to initiate Skype calls. When scanned, the QR scanner app opens skype and calls the user given to the payload generator.
        /// </summary>
        /// <param name="SkypeDto"></param>
        /// <returns></returns>
        [HttpPost("skype")]
        public IActionResult Createskype(SkypeDto skypeDto)
        {
            SkypeCall generator = new SkypeCall(skypeDto.skypeUsername);
            string payload = generator.ToString();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(skypeDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, skypeDto.Output);
        }

        /// <summary>
        /// Use it when you want to compose a SMS (message). You can choose if you want to create the message including text or just let the QR code open the messaging app with the given phonenumber.
        /// </summary>
        /// <param name="SkypeDto"></param>
        /// <returns></returns>
        [HttpPost("sms")]
        public IActionResult CreateSMS(SMSDto SMSDto)
        {
            SMS generator = new SMS(SMSDto.Number, SMSDto.Subject);
            string payload = generator.ToString();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(SMSDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, SMSDto.Output);
        }

        /// <summary>
        /// Use it when you want to compose a SMS (message). You can choose if you want to create the message including text or just let the QR code open the messaging app with the given phonenumber.
        /// </summary>
        /// <param name="SkypeDto"></param>
        /// <returns></returns>
        [HttpPost("url")]
        public IActionResult CreateURL(URLDto URLDto)
        {
            Url generator = new Url(URLDto.URL);
            string payload = generator.ToString();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(URLDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, URLDto.Output);
        }

        /// <summary>
        /// Use it to share your WhatApp pre-composed WhatsAppMessages. Once scanned, the QR code opens a WhatsApp chat with the given message.
        /// </summary>
        /// <param name="SkypeDto"></param>
        /// <returns></returns>
        [HttpPost("whatsapp")]
        public IActionResult CreateWhatsApp(WhatsAppDto whatsAppDto)
        {
            WhatsAppMessage generator = new WhatsAppMessage(whatsAppDto.Number, whatsAppDto.Message);
            string payload = generator.ToString();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(whatsAppDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, whatsAppDto.Output);
        }

        /// <summary>
        /// Use it when you want to share WiFi credentials. Good for meetings, house partys and conventions.
        /// </summary>
        /// <param name="WifiDto"></param>
        /// <returns></returns>
        [HttpPost("wifi")]
        public IActionResult CreateWifi(WifiDto wifiDto)
        {
            Enum.TryParse<WiFi.Authentication>(wifiDto.authenticationMode, out var authMode);
            WiFi generator = new WiFi(wifiDto.Ssid, wifiDto.Password,authMode, wifiDto.isHiddenSSID);
            string payload = generator.ToString();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(wifiDto.Size);

            var file = ImageToBytes.ImageToByteArray(qrCodeAsBitmap);
            return File(file, wifiDto.Output);
        }

    }
}
