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
        IEnumerable<Categoria> GetAllCategorias();
        CategoriaDto GetCategoriaById(int id);
        void InsertCategoria(Categoria categoria);
        void UpdateCategoria(Categoria categoria);
        void RemoveCategoria(Categoria categoria);
        void DeleteCategoria(int id);

    }
}
