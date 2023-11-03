using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/CatalogoDocumento")]
    [ApiController]
    public class CatalogoDocumentoController : Controller
    {
        private readonly ICatalogoDocumentoService _catalogoDocumentoService;
        

        public CatalogoDocumentoController(ICatalogoDocumentoService catalogoDocumentoService)
        {
            _catalogoDocumentoService = catalogoDocumentoService;
        }

        [HttpGet]
        public IActionResult GetAllCatalogoDocumento()
        {   
            ResponseDto response = _catalogoDocumentoService.GetAllCatalogoDocumento();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetCatalogoDocumentoById(int id)
        { 
            ResponseDto response = _catalogoDocumentoService.GetCatalogoDocumentoById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult InsertCatalogoDocumento(CatalogoDocumento catalogoDocumento)
        { 
            
            ResponseDto response = _catalogoDocumentoService.InsertCatalogoDocumento(catalogoDocumento);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateCatalogoDocumento(CatalogoDocumento catalogoDocumento)
        {

            ResponseDto response = _catalogoDocumentoService.UpdateCatalogoDocumento(catalogoDocumento);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCatalogoDocumento(CatalogoDocumento catalogoDocumento)
        {
            ResponseDto response = _catalogoDocumentoService.RemoveCatalogoDocumento(catalogoDocumento);
            return Ok();
        }

      

    }
}
