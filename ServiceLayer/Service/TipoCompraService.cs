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
    public class TipoCompraService : ITipoCompraService
    {
        private readonly IRepository<TipoCompra> _repository;
        private readonly IEstadoService _estadoService;

        public TipoCompraService(IRepository<TipoCompra> repository, IEstadoService estadoService)
        {
            _repository = repository;
            _estadoService = estadoService;
        }

        public ResponseDto GetAllTipoCompra()
        {
            try
            {
                IEnumerable<TipoCompra> tipoCompras = _repository.GetAll();
                List<TipoCompraDto> tipoCompraDto = new List<TipoCompraDto>();
                foreach (var tipoCompra in tipoCompras)
                {
                    tipoCompraDto.Add(new TipoCompraDto
                    {
                        Id = tipoCompra.Id,
                        TipoCompras = tipoCompra.TipoCompras,
                        Descripcion = tipoCompra.Descripcion,
                        FechaCreacion = tipoCompra.FechaCreacion,
                        FechaModificacion = tipoCompra.FechaModificacion,
                        CreadoPor = tipoCompra.CreadoPor,
                        ModificadoPor = tipoCompra.ModificadoPor,
                        EstadoId = tipoCompra.EstadoId,
                    });
                }
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "TipoCompra encontrado",
                    StatusCode = 200,
                    Data = tipoCompraDto
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "TipoCompra no encontrado",
                    StatusCode = 500,
                    Data = null
                };
                return responseDto;
            }
        }

        public ResponseDto GetTipoCompraById(int id)
        {
            try
            {
                TipoCompra tipoCompra = _repository.GetById(id);
                TipoCompraDto tipoCompraDto = new TipoCompraDto
                {
                    Id = tipoCompra.Id,
                    TipoCompras = tipoCompra.TipoCompras,
                    Descripcion = tipoCompra.Descripcion,
                    FechaCreacion = tipoCompra.FechaCreacion,
                    FechaModificacion = tipoCompra.FechaModificacion,
                    CreadoPor = tipoCompra.CreadoPor,
                    ModificadoPor = tipoCompra.ModificadoPor,
                    EstadoId = tipoCompra.EstadoId,
                   
                };
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "TipoCompra encontrado",
                    StatusCode = 200,
                    Data = tipoCompraDto
                };
                return responseDto;

            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "TipoCompra no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto InsertTipoCompra(TipoCompra tipoCompra)
        {
            try
            {
                _repository.Insert(tipoCompra);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "TipoCompra insertado correctamente",
                    StatusCode = 200,
                    Data = tipoCompra
                };
                return responseDto;

            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "TipoCompra no insertado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto RemoveTipoCompra(int id)
        {
            try
            {
                TipoCompra tipoCompra = _repository.GetById(id);
                _repository.Remove(tipoCompra);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "TipoCompra eliminado correctamente",
                    StatusCode = 200,
                    Data = tipoCompra
                };
                return responseDto;

            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "TipoCompra no eliminado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto UpdateTipoCompra(TipoCompra TipoCompra)
        {
            try
            {
                _repository.Update(TipoCompra);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "TipoCompra actualizado correctamente",
                    StatusCode = 200,
                    Data = TipoCompra
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "TipoCompra no actualizado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }

        }
    }
}
