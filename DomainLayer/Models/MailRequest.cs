using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class MailRequest
    {
        public MailRequest() { }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
