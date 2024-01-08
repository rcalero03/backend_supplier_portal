using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IProveedorCategoriaService
    {
        ResponseDto GetAllProveedorCategoria();
        ResponseDto GetProveedorCategoriaByProveedorId(int proveedorId);
        ResponseDto InsertProveedorCategoria(ProveedorCategoria ProveedorCategoria);
        ResponseDto UpdateProveedorCategoria(ProveedorCategoria ProveedorCategoria);
        ResponseDto RemoveProveedorCategoria(int id);
    }
}
