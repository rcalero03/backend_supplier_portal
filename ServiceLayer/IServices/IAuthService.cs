using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace ServiceLayer.IServices
{
    public interface IAuthService
    {
        JwtClaims DecodeJwtTokenAzure(string token);

        JwtAuth createToken(Usuario user);
    }
}
