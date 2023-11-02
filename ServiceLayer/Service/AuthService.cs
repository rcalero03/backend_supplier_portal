using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguracionGeneralService _configurationGeneralService;
        public AuthService(IConfiguracionGeneralService configurationGeneralService)
        {
            _configurationGeneralService = configurationGeneralService;
        }


        public JwtClaimsDto DecodeJwtTokenAzure(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token) as JwtSecurityToken;

                if (jwtToken != null)
                {
                    if (jwtToken.Claims != null)
                    {
                        var emailClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "email");
                        var appIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "appid");
                        var appDisplayNameClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "app_displayname");
                        var nameClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "name");
                        var expirationClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "exp");
                        var userIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "oid");

                        if (emailClaim != null && appIdClaim != null && appDisplayNameClaim != null && nameClaim != null && expirationClaim != null && userIdClaim != null)
                        {
                            var jwtClaims = new JwtClaimsDto
                            {
                                Email = emailClaim.Value,
                                AppId = appIdClaim.Value,
                                AppDisplayName = appDisplayNameClaim.Value,
                                Name = nameClaim.Value,
                                Expiration = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Convert.ToDouble(expirationClaim.Value)),
                                UserId = userIdClaim.Value
                            };

                            return jwtClaims;
                        }
                    }
                }

                // Si llegamos aquí, es porque no se encontraron todas las reclamaciones necesarias o había otros problemas con el token.
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al decodificar el token: " + ex.Message);
                return null;
            }
        }

        public JwtAuthDto createToken(Usuario user)
        {
            try
            {
                ConfiguracionGeneralDto jwtSettings = _configurationGeneralService.GetByCode("JWT");
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwtSettings.Valor3);

                DateTime expires = DateTime.Now.AddDays(int.Parse(jwtSettings.Valor5));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(user.Nombre, user.Nombre),
                        new Claim(user.Email, user.Email),
                    }),
                    Expires = expires,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                JwtAuthDto auth = new JwtAuthDto();
                auth.AccessToken = tokenHandler.WriteToken(token);
                auth.RefreshToken = tokenHandler.WriteToken(token);

                return auth;
            } catch (Exception ex) {
                Console.WriteLine("Error al crear el token: " + ex.Message);
                return null;
            }
        }

    }
}
