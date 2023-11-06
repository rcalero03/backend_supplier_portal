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
        ResponseDto GetProveedorCategoriaById(int id);
        ResponseDto InsertProveedorCategoria(ProveedorCategoria proveedorCategoria);
        ResponseDto UpdateProveedorCategoria(ProveedorCategoria proveedorCategoria);
        ResponseDto RemoveProveedorCategoria(int id);
    }
}
