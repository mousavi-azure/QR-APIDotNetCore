using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR_API.DTOs
{
    public class BitCoinDto:BaseDto
    {
        public string address { get; set; }
        public double? amount { get; set; } = 1;
        //Reference label
        public string lable { get; set; }
        //Referece text aka message
        public string Message { get; set; }
    }
}
