
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;
using supplierBackendAPIs.Utilities;
using Newtonsoft.Json.Linq;
using ServiceLayer.Service;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public AuthController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("login")]
    public IActionResult Authenticate([FromBody] Object data)
    {
        var token = JObject.Parse(data.ToString())["token"].ToString();
        if (TokenIsValid(token))
        {
            //var token = _jwtAuth.GenerateJwtToken();
            return Ok(new { token = "asdasdasdasd" });
        } 
        else
        {
            return Unauthorized();
        }
    }


    private bool TokenIsValid(string token)
    {
        _usuarioService.DecodeJwtTokenAzure(token);
        return true;
    }

}

