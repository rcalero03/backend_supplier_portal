using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface ITipoDocumentoService
    {
        IEnumerable<TipoDocumento> GetAllTipoDocumentos();
        TipoDocumento GetTipoDocumentoById(int id);
        void InsertTipoDocumento(TipoDocumento tipoDocumento);
        void UpdateTipoDocumento(TipoDocumento tipoDocumento);
        void RemoveTipoDocumento(TipoDocumento tipoDocumento);
    }
}
