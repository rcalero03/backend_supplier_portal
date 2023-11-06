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
    public  class ProveedorCategoriaService : IProveedorCategoriaService
    {
        private readonly IRepository<ProveedorCategoria> _repository;

        public ProveedorCategoriaService(IRepository<ProveedorCategoria> repository)
        {
            _repository = repository;
        }

        public ResponseDto GetAllProveedorCategoria()
        {
            try
            {
                IEnumerable<ProveedorCategoria> proveedorCategorias = _repository.GetAll();
                List<ProveedorCategoriaDto> proveedorCategoriaDto = new List<ProveedorCategoriaDto>();
                foreach (var proveedorCategoria in proveedorCategorias)
                {
                    proveedorCategoriaDto.Add(new ProveedorCategoriaDto
                    {
                        ProveedorId = proveedorCategoria.ProveedorId,
                        CategoriaId = proveedorCategoria.CategoriaId,
                        EstadoId = proveedorCategoria.EstadoId
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

        public ResponseDto GetProveedorCategoriaById(int id)
        {
            try
            {
                ProveedorCategoria proveedorCategoria = _repository.GetById(id);
                ProveedorCategoriaDto proveedorCategoriaDto = new ProveedorCategoriaDto
                {
                    ProveedorId = proveedorCategoria.ProveedorId,
                    CategoriaId = proveedorCategoria.CategoriaId,
                    EstadoId = proveedorCategoria.EstadoId
                };
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

        public ResponseDto InsertProveedorCategoria(ProveedorCategoria proveedorCategoria)
        {
            try
            {
                _repository.Insert(proveedorCategoria);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "ProveedorCategoria insertado correctamente",
                    StatusCode = 200,
                    Data = proveedorCategoria
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "ProveedorCategoria no insertado correctamente",
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
                    Message = "ProveedorCategoria no eliminado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto UpdateProveedorCategoria(ProveedorCategoria proveedorCategoria)
        {
            try
            {
                _repository.Update(proveedorCategoria);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "ProveedorCategoria actualizado correctamente",
                    StatusCode = 200,
                    Data = proveedorCategoria
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "ProveedorCategoria no actualizado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }
    }
}
