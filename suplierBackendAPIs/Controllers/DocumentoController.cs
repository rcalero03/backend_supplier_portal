using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/Documento")]
    [ApiController]
    public class DocumentoController : Controller
    {
        public readonly IDocumentoService _documentoService;

        public DocumentoController(IDocumentoService documentoService)
        {
            _documentoService = documentoService;
        }

        [HttpGet]
        public IActionResult GetAllDocumento()
        {
            ResponseDto response = _documentoService.GetAllDocumento();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetDocumentoById(int id)
        {
            ResponseDto response = _documentoService.GetDocumentoById(id);
            return Ok(response);
        }

        [HttpGet("getAllDocumentBySuppliers/{proveedorId}")]
        public IActionResult getAllDocumentBySuppliers(int proveedorId)
        {
            ResponseDto response = _documentoService.getAllDocumentBySuppliers(proveedorId);
            return Ok(response);
        }

        [HttpGet("getAllDocumentBySuppliersActive/{proveedorId}")]
        public IActionResult getAllDocumentBySuppliersActive(int proveedorId)
        {
            ResponseDto response = _documentoService.getAllDocumentoSupplierActive(proveedorId);
            return Ok(response);
        }


        [HttpPost]
        public IActionResult InsertDocumento(Documento documento)
        {
            ResponseDto response = _documentoService.InsertDocumento(documento);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateDocumento(Documento documento)
        {
            ResponseDto response = _documentoService.UpdateDocumento(documento);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDocumento(int id)
        {
            ResponseDto response = _documentoService.RemoveDocumento(id);
            return Ok(response);
        }

        [HttpPut("updateDocumenStatusRefused")]
        public IActionResult updateDocumenStatus(StatusDocumentDto statusDocument)
        {
            ResponseDto response = _documentoService.updateDocumenStatusRefused(statusDocument);
            return Ok(response);
        }

        [HttpPut("statusDocumentAproved/{Id}")]
        public IActionResult updateStatusDocument(int Id)
        {
            ResponseDto response = _documentoService.updateStatusDocumentAproved(Id);
            return Ok(response);
        }

        [HttpPut("statusDocumentExpired/{Id}")]
        public IActionResult updateStatusDocumentExpired(int Id)
        {
            _documentoService.updateDocumentStatusExpired(Id);
            return Ok();

        }


    }
}
