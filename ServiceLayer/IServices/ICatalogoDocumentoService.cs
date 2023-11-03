using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface ICatalogoDocumentoService
    {
        ResponseDto GetAllCatalogoDocumento();
        ResponseDto GetCatalogoDocumentoById(int paisId);
        ResponseDto InsertCatalogoDocumento(CatalogoDocumento catalogoDocumento);
        ResponseDto UpdateCatalogoDocumento(CatalogoDocumento catalogoDocumento);
        ResponseDto RemoveCatalogoDocumento(CatalogoDocumento catalogoDocumento);
    }
}
