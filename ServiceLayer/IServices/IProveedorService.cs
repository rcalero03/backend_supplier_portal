using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IProveedorService
    {
        ResponseDto GetAllProveedor();
        ResponseDto GetProveedorById(int id);
        ResponseDto InsertProveedor(Proveedor proveedor);
        ResponseDto UpdateProveedor(Proveedor proveedor);
        ResponseDto RemoveProveedor(int id);
    }
}
