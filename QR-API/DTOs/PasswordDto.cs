using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator.OneTimePassword;

namespace QR_API.DTOs
{
    public class PasswordDto:BaseDto
    {
        [Required]
        public OneTimePasswordAuthType Type { get; set; } = OneTimePasswordAuthType.TOTP;
        [Obsolete]
        [Required]
        public OoneTimePasswordAuthAlgorithm Algorithm { get; set; } = OoneTimePasswordAuthAlgorithm.SHA1;
        [Required]
        public string Issuer { get; set; }
        [Required]
        public string Secret { get; set; }
        [Required]
        public string Lable { get; set; }
        [Required]
        public int Digits { get; set; } = 6;
        public int? Counter { get; set; } = null;
        public int? Period { get; set; } = 30;

    }
}
