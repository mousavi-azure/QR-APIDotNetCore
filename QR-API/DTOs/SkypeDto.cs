using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QR_API.DTOs
{
    public class SkypeDto:BaseDto
    {
        [Required]
        public string skypeUsername { get; set; }
    }
}
