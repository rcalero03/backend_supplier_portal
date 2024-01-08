using DomainLayer.Models;
using DomainLayer.ModelsDto;
using RepositoryLayer;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly IRepository<TipoDocumento> _repository;
  

        public TipoDocumentoService(IRepository<TipoDocumento> repository)
        {
            _repository = repository;
        }

        public ResponseDto GetAllTipoDocumentos()
        {
            try
            {
                IEnumerable<TipoDocumento> tipoDocumentos = _repository.GetAll();
                List<TipoDocumentoDto> tipoDocumentoDto = new List<TipoDocumentoDto>();
                foreach (var tipoDocumento in tipoDocumentos)
                {
                   if(tipoDocumento.EstadoId == 1)
                    {
                        TipoDocumentoDto tipoDocumentoDto1 = new TipoDocumentoDto
                        {
                            Id = tipoDocumento.Id,
                            Nombre = tipoDocumento.Nombre,
                            Descripcion = tipoDocumento.Descripcion,
                            FechaCreacion = tipoDocumento.FechaCreacion,
                            FechaModificacion = tipoDocumento.FechaModificacion,
                            CreadoPor = tipoDocumento.CreadoPor,
                            ModificadoPor = tipoDocumento.ModificadoPor,
                            EstadoId = tipoDocumento.EstadoId
                        };
                        tipoDocumentoDto.Add(tipoDocumentoDto1);
                    }
                }

                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "TipoDocumento encontrado",
                    StatusCode = 200,
                    Data = tipoDocumentoDto
                };
                return response;

            }catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "TipoDocumento no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return response;
            }   
          
        }

        public string getTipoDocumentoById(int Id)
        {
            TipoDocumento tipoDocumento = _repository.GetById(Id);
            return tipoDocumento.Nombre ?? "";
        }

        public ResponseDto GetTipoDocumentoById(int id)
        {
            try
            {
                TipoDocumento tipoDocumento = _repository.GetById(id);
                TipoDocumentoDto tipoDocumentoDto = new TipoDocumentoDto
                {
                    Id = tipoDocumento.Id,
                    Nombre = tipoDocumento.Nombre,
                    Descripcion = tipoDocumento.Descripcion,
                    FechaCreacion = tipoDocumento.FechaCreacion,
                    FechaModificacion = tipoDocumento.FechaModificacion,
                    CreadoPor = tipoDocumento.CreadoPor,
                    ModificadoPor = tipoDocumento.ModificadoPor,
                    EstadoId = tipoDocumento.EstadoId
                };
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "TipoDocumento encontrado",
                    StatusCode = 200,
                    Data = tipoDocumentoDto
                };
                return response;
            }catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "TipoDocumento no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return response;
            }
          
        }

        public ResponseDto InsertTipoDocumento(TipoDocumento tipoDocumento)
        {
            try
            {
                _repository.Insert(tipoDocumento);
                _repository.SaveChange();
                TipoDocumentoDto tipoDocumentoDto = new TipoDocumentoDto
                {
                    Id = tipoDocumento.Id,
                    Nombre = tipoDocumento.Nombre,
                    Descripcion = tipoDocumento.Descripcion,
                    FechaCreacion = tipoDocumento.FechaCreacion,
                    FechaModificacion = tipoDocumento.FechaModificacion,
                    CreadoPor = tipoDocumento.CreadoPor,
                    ModificadoPor = tipoDocumento.ModificadoPor,
                    EstadoId = tipoDocumento.EstadoId
                };
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "TipoDocumento insertado",
                    StatusCode = 200,
                    Data = tipoDocumentoDto
                };
                return response;
            }catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "TipoDocumento no insertado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return response;
            }
           

        }

        public ResponseDto RemoveTipoDocumento(TipoDocumento tipoDocumento)
        {
            try
            {
                var tipoDocumentos = _repository.GetById(tipoDocumento.Id);
                _repository.Remove(tipoDocumentos);
                _repository.SaveChange();
                TipoDocumentoDto tipoDocumentoDto = new TipoDocumentoDto
                {
                    Id = tipoDocumento.Id,
                    Nombre = tipoDocumento.Nombre,
                    Descripcion = tipoDocumento.Descripcion,
                    FechaCreacion = tipoDocumento.FechaCreacion,
                    FechaModificacion = tipoDocumento.FechaModificacion,
                    CreadoPor = tipoDocumento.CreadoPor,
                    ModificadoPor = tipoDocumento.ModificadoPor,
                    EstadoId = tipoDocumento.EstadoId
                };
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "TipoDocumento eliminado",
                    StatusCode = 200,
                    Data = tipoDocumentoDto
                };

                return response;

            }catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "TipoDocumento no eliminado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return response;
            }
         
        }
        public ResponseDto UpdateTipoDocumento(TipoDocumento tipoDocumento)
        {
            try
            {
                    TipoDocumento documento = new TipoDocumento
                    {
                        Id = tipoDocumento.Id,
                        Nombre = tipoDocumento.Nombre,
                        Descripcion = tipoDocumento.Descripcion,
                        FechaCreacion = tipoDocumento.FechaCreacion,
                        FechaModificacion = DateTime.Now,
                        CreadoPor = tipoDocumento.CreadoPor,
                        ModificadoPor = tipoDocumento.ModificadoPor,
                        EstadoId = tipoDocumento.EstadoId
                    };
                    _repository.Update(documento);
                    _repository.SaveChange();

                
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "TipoDocumento actualizado",
                    StatusCode = 200
                };
                return response;
            }catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "TipoDocumento no actualizado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return response;
            }
            

        }

    }
}
