using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IUsuarioService
    {
        ResponseDto GetByEmail(loginDto loginDto);
        // ResponseDto InsertUsuario(Usuario usuario);
        //Usuario ValidateUser(JwtClaimsDto claims);
        //Usuario getByIdUsuario(int id);
        //ResponseDto validateUsuario(UsuarioDto usuarioDto);
    }
}
