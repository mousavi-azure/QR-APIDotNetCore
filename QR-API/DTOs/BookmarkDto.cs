using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR_API.DTOs
{
    public class BookmarkDto:BaseDto
    {
        //Url of the bookmark
        public string Url { get; set; }
        //Title of the bookmark
        public string Title { get; set; }
    }
}
