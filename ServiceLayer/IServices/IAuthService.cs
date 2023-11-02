using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using DomainLayer.ModelsDto;

namespace ServiceLayer.IServices
{
    public interface IAuthService
    {
        JwtClaimsDto DecodeJwtTokenAzure(string token);

        JwtAuthDto createToken(Usuario user);
    }
}
