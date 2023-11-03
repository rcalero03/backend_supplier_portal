﻿using DomainLayer.Models;
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
    public class SubtipoCompraService : ISubtipoCompraService
    {
        private readonly IRepository<SubtipoCompra> _repository;
        public SubtipoCompraService(IRepository<SubtipoCompra> repository)
        {
            _repository = repository; 
        }

        public ResponseDto GetAllSubtipoCompra()
        {
            try
            {
                IEnumerable<SubtipoCompra> subtipoCompra = _repository.GetAll();
                    List<SubtipoCompraDto> subtipoCompraDto = new List<SubtipoCompraDto>();
                    foreach (var subtipoCompras in subtipoCompra)
                    {
                        subtipoCompraDto.Add(new SubtipoCompraDto
                        {
                            Id = subtipoCompras.Id,
                            Descripcion = subtipoCompras.Descripcion,
                            TipoCompraId = subtipoCompras.TipoCompraId,
                            ProveedorId = subtipoCompras.ProveedorId
                        });
                    }
                    ResponseDto responseDto = new ResponseDto
                    {
                        Success = true,
                        Message = "SubtipoCompra encontrado",
                        StatusCode = 200,
                        Data = subtipoCompraDto
                    };
                    return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "SubtipoCompra no encontrado o no hay registros que mostrar",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
           
        }

        public ResponseDto GetSubtipoCompraById(int id)
        {
            try
            {
                SubtipoCompra subtipoCompra = _repository.GetById(id);
                SubtipoCompraDto subtipoCompraDto = new SubtipoCompraDto
                {
                    Id = subtipoCompra.Id,
                    Descripcion = subtipoCompra.Descripcion,
                    TipoCompraId = subtipoCompra.TipoCompraId,
                    ProveedorId = subtipoCompra.ProveedorId
                };
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "SubtipoCompra encontrado",
                    StatusCode = 200,
                    Data = subtipoCompraDto
                };
                return responseDto;

            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "SubtipoCompra no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto InsertSubtipoCompra(SubtipoCompra subtipoCompra)
        {
            try
            {
                _repository.Insert(subtipoCompra);
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "SubtipoCompra insertado correctamente",
                    StatusCode = 200,
                    Data = subtipoCompra
                };
                return responseDto;

            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "SubtipoCompra no insertado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto RemoveSubtipoCompra( int id)
        {
            try
            {
                SubtipoCompra subtipoCompra = _repository.GetById(id);
                _repository.Remove(subtipoCompra);
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "SubtipoCompra eliminado correctamente",
                    StatusCode = 200,
                    Data = subtipoCompra
                };
                return responseDto;

            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "SubtipoCompra no eliminado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto UpdateSubtipoCompra(SubtipoCompra subtipoCompra)
        {
            try
            {
                _repository.Update(subtipoCompra);
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "SubtipoCompra actualizado correctamente",
                    StatusCode = 200,
                    Data = subtipoCompra
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "SubtipoCompra no actualizado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }





    }
}