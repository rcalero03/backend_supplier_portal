using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IUsuarioService
    {
        Usuario GetByEmail(string email);

        string DecodeJwtTokenAzure(string token);
    }
}
