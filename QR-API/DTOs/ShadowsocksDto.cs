using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator;

namespace QR_API.DTOs
{
    public class ShadowsocksDto:BaseDto
    {
        [Required]
        public string hostname { get; set; }
        [Required]
        [Range(1,65535)]
        public int Port { get; set; }
        [Required]
        public string Password { get; set; }
        public string Tag { get; set; }

    }
}
