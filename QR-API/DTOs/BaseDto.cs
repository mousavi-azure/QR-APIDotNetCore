using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR_API.DTOs
{
    public class BaseDto
    {
        //Define max output size
        private const int _maxSize = 20;
        private int _size = 10;
        public int Size
        {
            get { return _size; }
            set { _size = (value > _maxSize || value <1) ? _maxSize : value; }
        }

        //Define Output Type
        private string _output = "image/jpeg";
        public string Output
        {
            get { return _output; }
            set { _output =outputType(value); }
        }

        string outputType(string input)
        {
            switch (input)
            {
                case "jpeg":
                    return "image/jpeg";
                    break;
                case "png":
                    return "image/png";
                    break;
                case "svg":
                    return "image/svg+xml";
                    break;
                default:
                    break;
            }
            return "image/jpeg";
        }

    }
}
