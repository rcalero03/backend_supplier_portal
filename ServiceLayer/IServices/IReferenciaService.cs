using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IReferenciaService
    {
        ResponseDto GetAllReferencias();
        ResponseDto GetReferenciaById(int id);
        ResponseDto InsertReferencia(Referencia referencia);
        ResponseDto UpdateReferencia(Referencia referencia);
        ResponseDto RemoveReferencia(int id);
    }
}
