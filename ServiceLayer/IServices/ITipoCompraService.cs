using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public  interface ITipoCompraService
    {
        ResponseDto GetAllTipoCompra();
        ResponseDto GetTipoCompraById(int id);
        ResponseDto InsertTipoCompra(TipoCompra TipoCompra);
        ResponseDto UpdateTipoCompra(TipoCompra TipoCompra);
        ResponseDto RemoveTipoCompra(int id);
        TipoCompraDto? GetTipoCompraDtoByIdBy(int id);

    }
}
