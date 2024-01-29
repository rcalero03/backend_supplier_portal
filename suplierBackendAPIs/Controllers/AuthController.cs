
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;
using Newtonsoft.Json.Linq;
using ServiceLayer.Service;
using DomainLayer.Models;
using DomainLayer.ModelsDto;
using supplierBackendAPIs.Utilities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public IConfiguration _configuration;
    public AuthController(IUsuarioService usuarioService, IConfiguration configuration)
    {
        _usuarioService = usuarioService;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult ValidateUsuario(loginDto loginDto)
    {
        ResponseDto response = _usuarioService.GetByEmail(loginDto);

        var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
        var email = loginDto.Username ?? "";

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, jwt?.Subject ?? ""),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer),
            new Claim("email", email.ToString()),
        };

        var key = jwt != null ? new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)) : null;

        if (key == null)
        {
            return Unauthorized();
        }

        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            jwt.Issuer,
            jwt.Audience,
            claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: signIn
        );

        response.Data = new
        {
            User = response.Data,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token)
        };

        return Ok(response);
    }


}

