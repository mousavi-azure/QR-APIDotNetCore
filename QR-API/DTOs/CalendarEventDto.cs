using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR_API.DTOs
{
    public class CalendarEventDto:BaseDto
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool AllDayEvent { get; set; }
    }
}
