using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR_API.DTOs
{
    public class GeoLocationDto:BaseDto
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
