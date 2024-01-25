﻿using DomainLayer.Models;
using DomainLayer.ModelsDto;
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
        ResponseDto updateDocumenStatusRefused(StatusDocumentDto statusDocument);
        ResponseDto updateStatusDocumentAproved(int IdDocument);
        void updateDocumentStatusExpired(int IdDocument);
        Task DocumentToExpiredAsync(int IdDocument);
        ResponseDto reportDocument(ReportDocumentDto reportDocument);
    }
}
