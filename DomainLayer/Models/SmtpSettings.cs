﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class SmtpSettings
    {
        public SmtpSettings() { }

        public string Server { get; set; }
        public string Por {  get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string UserName { get; set;}
        public string Password { get; set;}
    }
    
}
