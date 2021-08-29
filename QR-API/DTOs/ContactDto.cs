using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator.ContactData;

namespace QR_API.DTOs
{
    public class ContactDto:BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string WebSite { get; set; }
        public string street { get; set; }
        public string HouseNumber{ get; set; }
        public string City{ get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Note { get; set; }
        public string StateRegion { get; set; }
        public string AddressOrder { get; set; }
        public string Org { get; set; }

    }
}
