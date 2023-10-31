using DomainLayer.Models;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class UsuarioService : IUsuarioService
    {
        private IRepository<Usuario> _repository;

        public Usuario GetByEmail(string email)
        {
            return _repository.GetAll().Where(x => x.Email == email).FirstOrDefault();
        }

        public string DecodeJwtTokenAzure(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token) as JwtSecurityToken;

                if (jwtToken != null)
                {
                    // Verificar si Claims es nulo antes de intentar acceder a él
                    if (jwtToken.Claims != null)
                    {
                        var emailClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "email");

                        if (emailClaim != null)
                        {
                            return emailClaim.Value;
                        }
                    }
                }
                // Si llegamos aquí, es porque no se encontró el reclamo "email" o había otros problemas con el token.
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al decodificar el token: " + ex.Message);
                return null;
            }
        }

    }
}
