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
    public class SubtipoCompraService : ISubtipoCompraService
    {
        private readonly IRepository<SubtipoCompra> _repository;
        private ProveedorService _repositoryProveedor;
        private TipoCompraService _repositoryTipoCompra;
       
        public SubtipoCompraService(IRepository<SubtipoCompra> repository)
        {
            _repository = repository; 
        }

        public ResponseDto GetAllSubtipoCompra()
        {
            try
            {
                List<SubtipoCompra> subtipoCompra = new List<SubtipoCompra>();
                subtipoCompra = _repository.GetAllAsQueryable().Include(sc => sc.Proveedor)
                                                               .ThenInclude(p => p.Usuario)
                                                               .Include(x=>x.TipoCompra).ToList();

                    List<SubtipoCompraDto> subtipoCompraDto = new List<SubtipoCompraDto>();
                  
                    foreach (var subtipoCompras in subtipoCompra)
                    {
                         subtipoCompraDto.Add(new SubtipoCompraDto
                        {
                            Id = subtipoCompras.Id,
                            Descripcion = subtipoCompras.Descripcion,
                            TipoCompraId = subtipoCompras.TipoCompraId,
                            ProveedorId = subtipoCompras.ProveedorId,
                            Usuario = subtipoCompras.Proveedor?.Usuario?.Nombre,
                            Provedors = subtipoCompras.Proveedor?.Descripcion,
                            TipoCompras = subtipoCompras.TipoCompra?.TipoCompras

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
                _repository.SaveChange();  
                SubtipoCompraDto compraDto = new SubtipoCompraDto
                {
                    Id = subtipoCompra.Id,
                    Descripcion = subtipoCompra.Descripcion,
                    TipoCompraId = subtipoCompra.TipoCompraId,
                    ProveedorId = subtipoCompra.ProveedorId
                };

                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "SubtipoCompra insertado correctamente",
                    StatusCode = 200,
                    Data = compraDto
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
               _repository.SaveChange();
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
                _repository.SaveChange();
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
