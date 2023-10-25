using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace suplierBackendAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
       private readonly ITipoDocumentoService _tipoDocumentoService;
       private readonly IEstadoService _estadoService;

        public TipoDocumentoController(ITipoDocumentoService tipoDocumentoService)
        {
            _tipoDocumentoService = tipoDocumentoService;
        }

        [HttpGet]
        public IActionResult GetAllTipoDocumentos()
        {
               return Ok(_tipoDocumentoService.GetAllTipoDocumentos());
        }

        [HttpGet("{id}")]
        public IActionResult GetTipoDocumentoById(int id)
        {
            return Ok(_tipoDocumentoService.GetTipoDocumentoById(id));
        }

        [HttpPost]
        public IActionResult InsertTipoDocumento(TipoDocumento tipoDocumento)
        {
            _tipoDocumentoService.InsertTipoDocumento(tipoDocumento);
            return Ok("Tipo de documento insertado correctamente");
        }

        [HttpPut]
        public IActionResult UpdateTipoDocumento(TipoDocumento tipoDocumento)
        {
            _tipoDocumentoService.UpdateTipoDocumento(tipoDocumento);
            return Ok("Tipo de documento actualizado correctamente");
        }

        [HttpDelete]
        public IActionResult DeleteTipoDocumento(TipoDocumento tipoDocumento)
        {
            _tipoDocumentoService.RemoveTipoDocumento(tipoDocumento);
            return Ok("Tipo de documento eliminado correctamente");
        }
    }
}
