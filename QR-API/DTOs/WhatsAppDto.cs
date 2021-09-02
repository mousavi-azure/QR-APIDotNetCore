using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QR_API.DTOs
{
    public class WhatsAppDto: BaseDto
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
