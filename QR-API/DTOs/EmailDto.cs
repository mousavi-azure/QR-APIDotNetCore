using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR_API.DTOs
{
    public class EmailDto:BaseDto
    {
        public string MailReceiver { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
