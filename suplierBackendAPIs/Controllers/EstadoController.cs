using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Cryptography;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/Estado")]
    public class EstadoController : Controller
    {
        public readonly IEstadoService _estadoService;

       public EstadoController (IEstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ResponseDto response = _estadoService.stateDocument();
            return Ok(response);

        }
    }
}
