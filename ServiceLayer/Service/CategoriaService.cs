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

        public ResponseDto GetAllCategorias()
        { 
            ResponseDto response = new ResponseDto();
            IEnumerable<Categoria> categoria;
            try
            {
                categoria = _repository.GetAll();
                //recoremos la lista de categorias y la convertimos a una lista de categoriaDto
                List<CategoriaDto> categoriaDtos = new List<CategoriaDto>();
               foreach (var item in categoria)
                {
                    CategoriaDto categoriaDto = new CategoriaDto
                    {
                        Id = item.Id,
                        Nombre = item.Nombre == null ? string.Empty : item.Nombre,
                        Descripcion = item.Descripcion == null ? string.Empty : item.Descripcion,
                        GrupoCompra = item.GrupoCompra == null ? string.Empty : item.GrupoCompra,
                        Comprador = item.Comprador == null ? string.Empty : item.Comprador,
                        FechaCreacion = item.FechaCreacion == null ? DateTime.Now : item.FechaCreacion,
                        FechaModificacion = item.FechaModificacion == null ? DateTime.Now : item.FechaModificacion,
                        CreadoPor = item.CreadoPor == null ? 0 : item.CreadoPor,
                        ModificadoPor = item.ModificadoPor == null ? 0 : item.ModificadoPor,
                        EstadoId = item.EstadoId == null ? 0 : item.EstadoId
                    };
                    categoriaDtos.Add(categoriaDto);
                }           
              
               ResponseDto responseDto = new ResponseDto
               {
                    Success = true,
                    Message = "Categorias obtenidas correctamente",
                    StatusCode = 200,
                    Data = categoriaDtos,
               };
                return responseDto;
            }
            catch
            {
              ResponseDto responseDto = new ResponseDto
              {
                    Success = false,
                    Message = "Error al obtener las categorias",
                    StatusCode = 400,
                    Data = " ",
              };
                return responseDto;
            }
           
        }

        public ResponseDto InsertCategoria(Categoria categoria)
        {
           
            try
            {
                _repository.Insert(categoria);
                _repository.SaveChange();
                CategoriaDto categoriaDto = new CategoriaDto
                {
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
                ResponseDto response = new ResponseDto
                {
                    Data = categoriaDto,
                    Success = true,
                    Message = "Categoria insertada correctamente",
                    StatusCode = 200
                };
                return response;

            }
            catch
            {
              ResponseDto response = new ResponseDto
              {
                    Data = categoria,
                    Success = false,
                    Message = "Error al insertar la categoria",
                    StatusCode = 400
                };
                return response;
             }
         
        }

        public ResponseDto GetCategoriaById(int id)
        {
           
            List<CategoriaDto> categoriaDtos = new List<CategoriaDto>();

            try
            {
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
                categoriaDtos.Add(categoriaDto);
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "Categoria obtenida correctamente",
                    StatusCode = 200,
                    Data = categoriaDtos

                };
                return response;
            }catch
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "Error al obtener la categoria",
                    StatusCode = 400,
                    Data = categoriaDtos

                };
                return response;
            }
        }

        public ResponseDto RemoveCategoria(Categoria categoria)
        {
            try
            {
                var categoriaToRemove = _repository.GetById(categoria.Id);
                _repository.Remove(categoriaToRemove);
                _repository.SaveChange();
                CategoriaDto categoriaDto = new CategoriaDto
                {
                    Comprador = categoria.Comprador == null ? string.Empty : categoria.Comprador,  
                    Nombre = categoria.Nombre == null ? string.Empty : categoria.Nombre,

                    Descripcion = categoria.Descripcion == null ? string.Empty : categoria.Descripcion,
                    GrupoCompra = categoria.GrupoCompra == null ? string.Empty : categoria.GrupoCompra,
                    FechaCreacion = categoria.FechaCreacion == null ? DateTime.Now : categoria.FechaCreacion,
                    FechaModificacion = categoria.FechaModificacion == null ? DateTime.Now : categoria.FechaModificacion,
                    CreadoPor = categoria.CreadoPor == null ? 0 : categoria.CreadoPor,
                    ModificadoPor = categoria.ModificadoPor == null ? 0 : categoria.ModificadoPor,
                    EstadoId = categoria.EstadoId == null ? 0 : categoria.EstadoId
                };
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "Categoria eliminada correctamente",
                    StatusCode = 200,
                    Data = categoriaDto,
                };
                return response;
            }
            catch
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "Error al eliminar la categoria",
                    StatusCode = 400,
                    Data = "",
                };
                return response;
            }
          
        }

        public ResponseDto UpdateCategoria(Categoria categoria)
        {
            try
            {
                _repository.Update(categoria);
                _repository.SaveChange();
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
                ResponseDto response = new ResponseDto
                {
                 
                    Success = true,
                    StatusCode = 200,
                    Message = "Categoria actualizada correctamente",
                    Data = categoriaDto,

                };
                return response;
            }
            catch
            {
                ResponseDto response = new ResponseDto
                {
       
                    Success = false,
                    StatusCode = 400,
                    Message = "Error al actualizar la categoria",
                    Data = categoria,

                };
                return response;
            }

           
        }   

        public ResponseDto DeleteCategoria(int id)
        {
            try
            {
                var categoria = _repository.GetById(id);
                _repository.Remove(categoria);
                _repository.SaveChange();
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

                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "Categoria eliminada correctamente",
                    StatusCode = 200,
                    Data = categoriaDto
                };
                return response;
            }
            catch
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "Error al eliminar la categoria",
                    StatusCode = 400,
                    Data =  id,
                };
                return response;
            }
        }
    }
}
