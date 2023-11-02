using Microsoft.IdentityModel.Tokens;
using ServiceLayer.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace supplierBackendAPIs.Utilities
{
    public class JwtAuth
    {
        private readonly IConfiguracionGeneralService _configurationGeneralService;

        public string GenerateJwtToken (ClaimsIdentity claims)
        {
            var jwtSettings = _configurationGeneralService.GetByCode("JWT");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Valor1);

            DateTime expires = DateTime.Now.AddDays(int.Parse(jwtSettings.Valor3));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

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
