using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface ICategoriaService
    {
        ResponseDto GetAllCategorias();
        ResponseDto GetCategoriaById(int id);
        ResponseDto InsertCategoria(Categoria categoria);
        ResponseDto UpdateCategoria(Categoria categoria);
        ResponseDto RemoveCategoria(Categoria categoria);
        ResponseDto DeleteCategoria(int id);

    }
}
