using Azure;
using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;
using supplierBackendAPIs.Utilities;
using System.Diagnostics.Metrics;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/Documento")]
    [ApiController]
    [Authorize]
    public class DocumentoController : Controller
    {
        public readonly IDocumentoService _documentoService;
        public readonly IConfiguration _configuration;



        public DocumentoController(IDocumentoService documentoService, IConfiguration configuration)
        {
            _documentoService = documentoService;
            _configuration = configuration;

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

        [HttpPost("uploadAzureDocumento")]
        public async  Task<IActionResult> UploadAzureDocumento(IFormFile file)
        {
            AzureDocumentoDTO AzureConfig = new AzureDocumentoDTO();
            var Azure = _configuration.GetSection("AzureBlobSettings").Get<AzureBlobSettings>();
            AzureConfig.containerName = Azure.containerName;
            AzureConfig.accountName = Azure.accountName;
            AzureConfig.sasToken = Azure.sasToken;
            AzureConfig.sasUrl = Azure.sasUrl;

            ResponseDto response = await _documentoService.uploadAzureDocumento(file, AzureConfig);
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
        public async Task<IActionResult> updateDocumenStatus(StatusDocumentDto statusDocument)
        {
            ResponseDto response = await _documentoService.updateDocumenStatusRefusedAsync(statusDocument);
            return Ok(response);
        }

        [HttpPut("statusDocumentAproved")]
        public IActionResult deleteDocumenStatus(int id)
        {
            ResponseDto response = _documentoService.updateStatusDocumentAproved(id);
            return Ok(response);
        }


        [HttpPost("ReportDocument")]
        public IActionResult GetDocument(ReportDocumentDto reportDocument) {
           ResponseDto responseDto = _documentoService.reportDocument(reportDocument);
            return Ok(responseDto);
        }


    }
}
