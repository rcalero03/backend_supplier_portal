using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface  IEmailService
    {
        Task SentEmailAsync(MailRequestDto request);
    }
}
