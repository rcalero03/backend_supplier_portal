using Azure;
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
    public  class CatalogoDocumentoService : ICatalogoDocumentoService
    {
        private readonly IRepository<CatalogoDocumento> _repository;

        public CatalogoDocumentoService(IRepository<CatalogoDocumento> repository)
        {
            _repository = repository;
        }

         public ResponseDto GetAllCatalogoDocumento()
        { 
           
            try
            {

                List<CatalogoDocumentoDto> catalogoDocumentoDtos = new List<CatalogoDocumentoDto>();
                foreach (var catalogoDocumento in _repository.GetAllAsQueryable().Include(x=>x.TipoDocumento))
                {
                  if(catalogoDocumento.EstadoId==1)
                    {
                        catalogoDocumentoDtos.Add(new CatalogoDocumentoDto
                        {
                            Id = catalogoDocumento.Id,
                            Nombre = catalogoDocumento.Nombre == null ? string.Empty : catalogoDocumento.Nombre,
                            Descripcion = catalogoDocumento.Descripcion == null ? string.Empty : catalogoDocumento.Descripcion,
                            Requerido = catalogoDocumento.Requerido = catalogoDocumento.Requerido,
                            FechaCreacion = catalogoDocumento.FechaCreacion == null ? DateTime.Now : catalogoDocumento.FechaCreacion,
                            FechaModificacion = catalogoDocumento.FechaModificacion == null ? DateTime.Now : catalogoDocumento.FechaModificacion,
                            CreadoPor = catalogoDocumento.CreadoPor == null ? 0 : catalogoDocumento.CreadoPor,
                            ModificadoPor = catalogoDocumento.ModificadoPor == null ? 0 : catalogoDocumento.ModificadoPor,
                            EstadoId = catalogoDocumento.EstadoId,
                            TipoDocumentoId = catalogoDocumento.TipoDocumentoId,
<<<<<<< HEAD
=======
                            TipoDocumentoName = catalogoDocumento.TipoDocumento.Nombre
>>>>>>> f75f45315f91202521f7aa2b21765c5df2d357f1
                        });
                    }
                }
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "CatalogoDocumento encontrado",
                    StatusCode = 200,
                    Data = catalogoDocumentoDtos
                };
                return responseDto;
            }
            catch(Exception ex)
            {
                   ResponseDto responseDto = new ResponseDto
                   {
                    Success = false,
                    Message = "CatalogoDocumento no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }

        }
        public ResponseDto getAllCatalogoDocumentoByTipoDocumentoId(int tipoDocumentoId)
        {
            try
            {
                List<CatalogoDocumentoDto> catalogoDocumentoDtos = new List<CatalogoDocumentoDto>();
                foreach (var i in _repository.GetAll())
                {
                    if(i.TipoDocumentoId == tipoDocumentoId)
                    {
                        catalogoDocumentoDtos.Add(new CatalogoDocumentoDto
                        {
                            Id = i.Id,
                            Nombre = i.Nombre == null ? string.Empty : i.Nombre,
                            Descripcion = i.Descripcion == null ? string.Empty : i.Descripcion,
                            Requerido = i.Requerido = i.Requerido,
                            FechaCreacion = i.FechaCreacion == null ? DateTime.Now : i.FechaCreacion,
                            FechaModificacion = i.FechaModificacion == null ? DateTime.Now : i.FechaModificacion,
                            CreadoPor = i.CreadoPor == null ? 0 : i.CreadoPor,
                            ModificadoPor = i.ModificadoPor == null ? 0 : i.ModificadoPor,
                            EstadoId = i.EstadoId,
                            TipoDocumentoId = i.TipoDocumentoId,
                            TipoDocumentoName = i.TipoDocumento.Nombre
                        });
                    }
                }
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "CatalogoDocumento encontrado",
                    StatusCode = 200,
                    Data = catalogoDocumentoDtos
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "CatalogoDocumento no encontrado",
                    StatusCode = 404,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto GetCatalogoDocumentoById(int id)
        {
            try
            {
                List<CatalogoDocumentoDto> catalogoDocumentoDtos = new List<CatalogoDocumentoDto>();
                CatalogoDocumento catalogoDocumento = _repository.GetById(id);
                catalogoDocumentoDtos.Add(new CatalogoDocumentoDto
                {
                    Id = catalogoDocumento.Id,
                    Nombre = catalogoDocumento.Nombre == null ? string.Empty : catalogoDocumento.Nombre,
                    Descripcion = catalogoDocumento.Descripcion == null ? string.Empty : catalogoDocumento.Descripcion,
                    Requerido = catalogoDocumento.Requerido = catalogoDocumento.Requerido,
                    FechaCreacion = catalogoDocumento.FechaCreacion == null ? DateTime.Now : catalogoDocumento.FechaCreacion,
                    FechaModificacion = catalogoDocumento.FechaModificacion == null ? DateTime.Now : catalogoDocumento.FechaModificacion,
                    CreadoPor = catalogoDocumento.CreadoPor == null ? 0 : catalogoDocumento.CreadoPor,
                    ModificadoPor = catalogoDocumento.ModificadoPor == null ? 0 : catalogoDocumento.ModificadoPor,
                    EstadoId = catalogoDocumento.EstadoId,
                    TipoDocumentoId = catalogoDocumento.TipoDocumentoId,
                    TipoDocumentoName = catalogoDocumento.TipoDocumento.Nombre

                });
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "CatalogoDocumento encontrado",
                    StatusCode = 200,
                    Data = catalogoDocumentoDtos
                };

                return response;

            }
            catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "CatalogoDocumento no encontrado",
                    StatusCode = 404,
                    Data = ex.Message
                };
                return response;
            }
        
 
          
        }

        public ResponseDto InsertCatalogoDocumento(CatalogoDocumento catalogoDocumento)
        {
            try
            {
                _repository.Insert(catalogoDocumento);
                _repository.SaveChange();
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "CatalogoDocumento insertado correctamente",
                    StatusCode = 200,
                    Data = catalogoDocumento
                };
                return response;

            }catch(Exception ex)
            {
               ResponseDto response = new ResponseDto
               {
                    Success = false,
                    Message = "CatalogoDocumento no insertado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return response;
            }
            
        }

        public ResponseDto RemoveCatalogoDocumento(CatalogoDocumento catalogoDocumento)
        {
            try
            {
                var catalogoDocumentoToRemove = _repository.GetById(catalogoDocumento.Id);
                _repository.Remove(catalogoDocumentoToRemove);
                _repository.SaveChange();

                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "CatalogoDocumento eliminado correctamente",
                    StatusCode = 200,
                    Data = catalogoDocumento
                };
                return response;
            }catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "Catalogo Documento no eliminado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return response;
            }
        }

        public ResponseDto UpdateCatalogoDocumento(CatalogoDocumento catalogoDocumento)
        {
            try
            {
                _repository.Update(catalogoDocumento);
                _repository.SaveChange();

                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "CatalogoDocumento actualizado correctamente",
                    StatusCode = 200,
                    Data = catalogoDocumento
                };
                return response;
            }catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "CatalogoDocumento no actualizado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return response;
            }
           
        }



    }
}
