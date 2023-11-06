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
    public  class ReferenciaService : IReferenciaService
    {
        private readonly IRepository<Referencia> _repository;

        public ReferenciaService(IRepository<Referencia> repository)
        {
            _repository = repository;
        }

        public ResponseDto GetAllReferencias()
        {
            try
            {
                IEnumerable<Referencia> referencias = _repository.GetAll();
                List<ReferenciaDto> referenciaDto = new List<ReferenciaDto>();
                foreach (var referencia in referencias)
                {
                    referenciaDto.Add(new ReferenciaDto
                    {
                        Id = referencia.Id,
                        Nombre = referencia.Nombre,
                        Descripcion = referencia.Descripcion,
                        FechaCreacion = referencia.FechaCreacion,
                        FechaModificacion = referencia.FechaModificacion,
                        CreadoPor = referencia.CreadoPor,
                        ModificadoPor = referencia.ModificadoPor,
                        EstadoId = referencia.EstadoId,
                    });
                }
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "Referencia encontrado",
                    StatusCode = 200,
                    Data = referenciaDto
                };
                return response;
            }
            catch (Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "Referencia no encontrado",
                    StatusCode = 500,
                    Data = null
                };
                return response;
            }
        }

        public ResponseDto GetReferenciaById(int id)
        {
            try
            {
                Referencia referencia = _repository.GetById(id);
                ReferenciaDto referenciaDto = new ReferenciaDto
                {
                    Id = referencia.Id,
                    Nombre = referencia.Nombre,
                    Descripcion = referencia.Descripcion,
                    FechaCreacion = referencia.FechaCreacion,
                    FechaModificacion = referencia.FechaModificacion,
                    CreadoPor = referencia.CreadoPor,
                    ModificadoPor = referencia.ModificadoPor,
                    EstadoId = referencia.EstadoId,
                };
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "Referencia encontrado",
                    StatusCode = 200,
                    Data = referenciaDto
                };
                return response;
            }catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "Referencia no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return response;
            }
        }

        public ResponseDto InsertReferencia(Referencia referencia)
        {
            try
            {
                _repository.Insert(referencia);
                _repository.SaveChange();
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "Referencia insertado correctamente",
                    StatusCode = 200,
                    Data = referencia
                };
                return response;
            }catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "Referencia no insertado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return response;
            }
        }

        public ResponseDto RemoveReferencia(int id)
        {
            try
            { 
                Referencia referencia = _repository.GetById(id);
                _repository.Remove(referencia);
                _repository.SaveChange();
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "Referencia eliminado correctamente",
                    StatusCode = 200,
                    Data = referencia
                };
                return response;
            }catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "Referencia no eliminado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return response;
            }
        }


        public ResponseDto UpdateReferencia(Referencia referencia)
        {
            try
            {
                _repository.Update(referencia);
                _repository.SaveChange();
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "Referencia actualizado correctamente",
                    StatusCode = 200,
                    Data = referencia
                };
                return response;
            }catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "Referencia no actualizado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return response;
            }
        }




    }
}
