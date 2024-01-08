using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface ITipoDocumentoService
    {
        ResponseDto GetAllTipoDocumentos();
        ResponseDto GetTipoDocumentoById(int id);
        ResponseDto InsertTipoDocumento(TipoDocumento tipoDocumento);
        ResponseDto UpdateTipoDocumento(TipoDocumento tipoDocumento);
        ResponseDto RemoveTipoDocumento(TipoDocumento tipoDocumento);
        string getTipoDocumentoById(int Id);

    }
}
