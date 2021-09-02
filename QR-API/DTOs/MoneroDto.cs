using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QR_API.DTOs
{
    public class MoneroDto:BaseDto
    {
        [Required]
        public string address { get; set; }
        public float? txAmount { get; set; }
        public string txPaymentId { get; set; }
        public string recipientName { get; set; }
        public string txDescription { get; set; }

    }
}
