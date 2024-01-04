using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class ProveedorCategoriaService : IProveedorCategoriaService
    {
        public readonly IRepository<ProveedorCategoria> _repository;

        public ProveedorCategoriaService(IRepository<ProveedorCategoria> repository)
        {
            _repository = repository;
        }

        public ResponseDto GetAllProveedorCategoria()
        {
            try
            {
                IEnumerable<ProveedorCategoria> proveedorCategorias = _repository.GetAllAsQueryable()
                                                  .Include(x => x.Proveedor).Include(y => y.Categoria);
                List<ProveedorCategoriaDto> proveedorCategoriaDto = new List<ProveedorCategoriaDto>();
                foreach (var proveedorCategoria in proveedorCategorias)
                {
                    proveedorCategoriaDto.Add(new ProveedorCategoriaDto
                    {
                        Id = proveedorCategoria.Id,
                        ProveedorId = proveedorCategoria.ProveedorId,
                        CategoriaId = proveedorCategoria.CategoriaId,
                        Proveedor = proveedorCategoria.Proveedor?.Empresa,
                        Categoria = proveedorCategoria.Categoria?.Nombre
                    });
                }
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "ProveedorCategoria encontrado",
                    StatusCode = 200,
                    Data = proveedorCategoriaDto
                };
                return responseDto;

            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "ProveedorCategoria no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto GetProveedorCategoriaByProveedorId(int proveedorId)
        {
            try
            {
                IEnumerable<ProveedorCategoria> proveedorCategorias = _repository.GetAllAsQueryable()
                                                                      .Include(y=>y.Categoria);
                List<CategoriaDto> CategoriaDto = new List<CategoriaDto>();
                foreach (var proveedorCategoria in proveedorCategorias)
                {
                    if(proveedorCategoria.ProveedorId == proveedorId)
                    {
                        CategoriaDto.Add(new CategoriaDto
                        {
                            //este ID corresponde al ID de la tabla ProveedorCategoria, mas no al ID de la tabla Categoria
                            Id = proveedorCategoria.Id,
                            Nombre = proveedorCategoria.Categoria?.Nombre,
                            Descripcion = proveedorCategoria.Categoria?.Descripcion,
                            GrupoCompra = proveedorCategoria.Categoria?.GrupoCompra,
                            Comprador = proveedorCategoria.Categoria?.Comprador,
                        });
                    }
                }
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "ProveedorCategoria encontrado",
                    StatusCode = 200,
                    Data = CategoriaDto
                };
                return responseDto;
            }
            catch (Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "ProveedorCategoria no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto InsertProveedorCategoria(ProveedorCategoria ProveedorCategoria)
        {
            try
            { 
                if(_repository.GetAllAsQueryable().Any(x => x.ProveedorId == ProveedorCategoria.ProveedorId && x.CategoriaId == ProveedorCategoria.CategoriaId))
                {
                    ResponseDto responseDto = new ResponseDto
                    {
                        Success = false,
                        Message = "El proveedor ya posee la categoria",
                        StatusCode = 500,
                        Data = null
                    };
                    return responseDto;
                }
                else
                {
                    _repository.Insert(ProveedorCategoria);
                    _repository.SaveChange();
                    ResponseDto responseDto = new ResponseDto
                    {
                        Success = true,
                        Message = "Proveedor Categoria insertado correctamente",
                        StatusCode = 200,
                        Data = ProveedorCategoria
                    };
                    return responseDto;
                }
              
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "ProveedorCategoria no insertado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto RemoveProveedorCategoria(int id)
        {
            try
            {
                ProveedorCategoria proveedorCategoria = _repository.GetById(id);
                _repository.Remove(proveedorCategoria);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "ProveedorCategoria eliminado correctamente",
                    StatusCode = 200,
                    Data = proveedorCategoria
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "ProveedorCategoria no eliminado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto UpdateProveedorCategoria(ProveedorCategoria ProveedorCategoria)
        {
            try
            {
                _repository.Update(ProveedorCategoria);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "ProveedorCategoria actualizado correctamente",
                    StatusCode = 200,
                    Data = ProveedorCategoria
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "ProveedorCategoria no actualizado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }
    }
}
