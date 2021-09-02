using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator;

namespace QR_API.DTOs
{
    public class WifiDto : BaseDto
    {
        [Required]
        public string Ssid { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string authenticationMode { get; set; }
        [Required]
        public bool isHiddenSSID { get; set; } = false;
    }
}
