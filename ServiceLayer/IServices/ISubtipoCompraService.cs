using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface ISubtipoCompraService
    {
        ResponseDto GetAllSubtipoCompra();
        ResponseDto GetSubtipoCompraById(int id);
        ResponseDto InsertSubtipoCompra(SubtipoCompra SubtipoCompra);
        ResponseDto UpdateSubtipoCompra(SubtipoCompra SubtipoCompra);
        ResponseDto RemoveSubtipoCompra(int id);
        ResponseDto getSubtipoCompraByTipoCompraId(int id);
    }
}
