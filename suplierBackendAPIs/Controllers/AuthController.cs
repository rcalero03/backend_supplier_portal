
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;
using Newtonsoft.Json.Linq;
using ServiceLayer.Service;
using DomainLayer.Models;

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

            JwtClaims jwtClaims = _authService.DecodeJwtTokenAzure(token);

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

                JwtAuth auth = _authService.createToken(verifyUser);

                return Ok(new
                {
                    status = "200",
                    message = "Successful login",
                    data = auth.ToString()
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
                data = ""
            });
        }
    }

}

