using DomainLayer.Models;
using DomainLayer.ModelsDto;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class CategoriaService : ICategoriaService
    {
        private IRepository<Categoria> _repository;

        public CategoriaService(IRepository<Categoria> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Categoria> GetAllCategorias()
        {
            return _repository.GetAll();
        }

        public void InsertCategoria(Categoria categoria)
        {
            _repository.Insert(categoria);
            _repository.SaveChange();
        }

        public CategoriaDto GetCategoriaById(int id)
        {
            List<CategoriaDto> categoriaDtos = new List<CategoriaDto>();
            Categoria categoria = _repository.GetById(id);
            
            CategoriaDto categoriaDto = new CategoriaDto
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre == null ? string.Empty : categoria.Nombre,
                Descripcion = categoria.Descripcion == null ? string.Empty : categoria.Descripcion,
                GrupoCompra = categoria.GrupoCompra == null ? string.Empty : categoria.GrupoCompra,
                Comprador = categoria.Comprador == null ? string.Empty : categoria.Comprador,
                FechaCreacion = categoria.FechaCreacion == null ? DateTime.Now : categoria.FechaCreacion,
                FechaModificacion = categoria.FechaModificacion == null ? DateTime.Now : categoria.FechaModificacion,
                CreadoPor = categoria.CreadoPor == null ? 0 : categoria.CreadoPor,
                ModificadoPor = categoria.ModificadoPor == null ? 0 : categoria.ModificadoPor,
                EstadoId = categoria.EstadoId == null ? 0 : categoria.EstadoId

            };
        
            return categoriaDto;
        }

        public void RemoveCategoria(Categoria categoria)
        {
            var categoriaToRemove = _repository.GetById(categoria.Id);
            _repository.Remove(categoriaToRemove);
            _repository.SaveChange();
        }

        public void UpdateCategoria(Categoria categoria)
        {
            _repository.Update(categoria);
            _repository.SaveChange();
        }   

        public void DeleteCategoria(int id)
        {
            var categoria = _repository.GetById(id);
            _repository.Remove(categoria);
            _repository.SaveChange();
        }
    }
}
