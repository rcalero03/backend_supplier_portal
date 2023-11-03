using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
    public class ResponseDto
    {
        public bool Success { get; set; }
        public string ? Message { get; set; }
        public object ? Data { get; set; } = null;
        public int StatusCode { get; set; }
    }
}
