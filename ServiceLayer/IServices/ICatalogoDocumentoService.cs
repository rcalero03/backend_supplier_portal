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
        IEnumerable<CatalogoDocumento> GetAllCatalogoDocumento();
        List<CatalogoDocumentoDto> GetCatalogoDocumentoById(int paisId);
        void InsertCatalogoDocumento(CatalogoDocumento catalogoDocumento);
        void UpdateCatalogoDocumento(CatalogoDocumento catalogoDocumento);
        void RemoveCatalogoDocumento(CatalogoDocumento catalogoDocumento);
    }
}
