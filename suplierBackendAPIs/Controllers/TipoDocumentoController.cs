using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace suplierBackendAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoDocumentoController : ControllerBase
    {
       private readonly ITipoDocumentoService _tipoDocumentoService;

        public TipoDocumentoController(ITipoDocumentoService tipoDocumentoService)
        {
            _tipoDocumentoService = tipoDocumentoService;
        }

        [HttpGet]
        public IActionResult GetAllTipoDocumentos()
        {
          ResponseDto response = _tipoDocumentoService.GetAllTipoDocumentos();
               return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetTipoDocumentoById(int id)
        { 
            ResponseDto response = _tipoDocumentoService.GetTipoDocumentoById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult InsertTipoDocumento(TipoDocumento tipoDocumento)
        {
            ResponseDto response = _tipoDocumentoService.InsertTipoDocumento(tipoDocumento);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateTipoDocumento(TipoDocumento tipoDocumento)
        {
             ResponseDto response = _tipoDocumentoService.UpdateTipoDocumento(tipoDocumento);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult DeleteTipoDocumento(TipoDocumento tipoDocumento)
        {
             ResponseDto response = _tipoDocumentoService.RemoveTipoDocumento(tipoDocumento);
            return Ok(response);
        }
    }
}
