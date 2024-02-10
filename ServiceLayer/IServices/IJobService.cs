using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IJobService
    {
        void ValidDocumentEmailAsync();
        Task DocumentToExpiredAsync(int IdDocument);
        Task updateDocumentStatusExpired(int IdDocument);
        Task pruebaCorreo();
    }
}
