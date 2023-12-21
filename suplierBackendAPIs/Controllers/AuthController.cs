
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;
using Newtonsoft.Json.Linq;
using ServiceLayer.Service;
using DomainLayer.Models;
using DomainLayer.ModelsDto;
using supplierBackendAPIs.Utilities;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    private readonly IAuthService _authService;

    public AuthController(IUsuarioService usuarioService, IAuthService authService)
    {
        _usuarioService = usuarioService;
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Authenticate([FromBody] Object data)
    {
        try
        {
            var token = JObject.Parse(json: data.ToString())["token"].ToString();

            if (token == null)
            {
                return Ok(new
                {
                    status = "200",
                    message = "token is null",
                    data = ""
                });
            }

            JwtClaimsDto jwtClaims = _authService.DecodeJwtTokenAzure(token);

            if (jwtClaims != null)
            {
                Usuario verifyUser = _usuarioService.ValidateUser(jwtClaims);

                if (verifyUser == null)
                {
                    return Ok(new
                    {
                        status = "200",
                        message = "Error creating user",
                        data = ""
                    });
                }

                JwtAuthDto auth = _authService.createToken(verifyUser);

                return Ok(new
                {
                    status = "200",
                    message = "Successful login",
                    data = new
                    {
                        access_token = auth.AccessToken,
                        refresh_token = auth.RefreshToken,
                    }
                });
            }
            else
            {
                return Ok(new
                {
                    status = "200",
                    message = "The token is not valid",
                    data = ""
                });
            }
        } catch (Exception ex)
        {
            return Ok(new
            {
                status = "200",
                message = "Server error",
                data = ex
            });
        }

    }

}

