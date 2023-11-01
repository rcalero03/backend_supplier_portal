using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(_catalogoDocumentoService.GetAllCatalogoDocumento());
        }

        [HttpGet("{id}")]
        public IActionResult GetCatalogoDocumentoById(int id)
        {
            return Ok(_catalogoDocumentoService.GetCatalogoDocumentoById(id));
        }

        [HttpPost]
        public IActionResult InsertCatalogoDocumento(CatalogoDocumento catalogoDocumento)
        {
            _catalogoDocumentoService.InsertCatalogoDocumento(catalogoDocumento);
            var response = new
            {
                status = 200,
                message = "CatalogoDocumento creado correctamente"
            };
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateCatalogoDocumento(CatalogoDocumento catalogoDocumento)
        {
            _catalogoDocumentoService.UpdateCatalogoDocumento(catalogoDocumento);
            var response = new
            {
                status = 200,
                message = "CatalogoDocumento actualizado correctamente"
            };
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCatalogoDocumento(CatalogoDocumento catalogoDocumento)
        {
            _catalogoDocumentoService.RemoveCatalogoDocumento(catalogoDocumento);
            return Ok();
        }

      

    }
}
