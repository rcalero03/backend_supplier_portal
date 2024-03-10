using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IDocumentoService
    {
        ResponseDto GetAllDocumento();
        ResponseDto GetDocumentoById(int id);
        ResponseDto InsertDocumento(Documento Documento);
        ResponseDto UpdateDocumento(Documento Documento);
        ResponseDto RemoveDocumento(int id);
        ResponseDto getAllDocumentBySuppliers(int proveedorId);
        ResponseDto getAllDocumentoSupplierActive(int proveedorId);
        Task<ResponseDto> updateDocumenStatusRefusedAsync(StatusDocumentDto statusDocument);
        ResponseDto updateStatusDocumentAproved(int IdDocument);
        ResponseDto reportDocument(ReportDocumentDto reportDocument);
        Task<ResponseDto> uploadAzureDocumento(IFormFile file, AzureDocumentoDTO AzureConfig);
    }
}
