﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace ServiceLayer.IServices
{
    internal interface IEmailService
    {
        Task SendEmailAsynAsync(MailRequest request);
    }
}
