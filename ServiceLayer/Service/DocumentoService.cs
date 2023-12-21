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
    public class DocumentoService : IDocumentoService
    {
        public readonly IRepository<Documento> _repository;

        public DocumentoService(IRepository<Documento> repository)
        {
            _repository = repository;
        }

        public ResponseDto GetAllDocumento()
        {
            try
            {
                IEnumerable<Documento> documentos = _repository.GetAll();
                List<DocumentoDto> documentoDto = new List<DocumentoDto>();
                foreach (var documento in documentos)
                {
                    documentoDto.Add(new DocumentoDto
                    {
                        Id = documento.Id,
                        URL = documento.Nombre,
                        FechaEmicion = documento.FechaEmicion,
                        FechaVencimiento = documento.FechaVencimiento,
                        EstadoId = documento.EstadoId,
                        ProveedorId = documento.ProveedorId,
                        CatalogoDocumentoId = documento.CatalogoDocumentoId,
                        FechaCreacion = documento.FechaCreacion,
                        FechaModificacion = documento.FechaModificacion,
                        CreadoPor = documento.CreadoPor,
                        ModificadoPor = documento.ModificadoPor
                    });
                }
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Documento encontrado",
                    StatusCode = 200,
                    Data = documentoDto
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Documento no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto getAllDocumentBySuppliers(int proveedorId)
        {
            try
            {
                List<DocumentoDto> documentoDto = new List<DocumentoDto>();
                IEnumerable<Documento> documentos = _repository.GetAll().Where(x => x.ProveedorId == proveedorId);
                foreach (var documento in documentos)
                {
                    documentoDto.Add(new DocumentoDto
                    {
                        Id = documento.Id,
                        URL = documento.Nombre,
                        FechaEmicion = documento.FechaEmicion,
                        FechaVencimiento = documento.FechaVencimiento,
                        EstadoId = documento.EstadoId,
                        ProveedorId = documento.ProveedorId,
                        CatalogoDocumentoId = documento.CatalogoDocumentoId,
                        FechaCreacion = documento.FechaCreacion,
                        FechaModificacion = documento.FechaModificacion,
                        CreadoPor = documento.CreadoPor,
                        ModificadoPor = documento.ModificadoPor
                    });
                }
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Documento encontrado",
                    StatusCode = 200,
                    Data = documentoDto
                };

                return responseDto;
            }
            catch (Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Documento no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }


        public ResponseDto GetDocumentoById(int id)
        {
            try
            {
                Documento documento = _repository.GetById(id);
                DocumentoDto documentoDto = new DocumentoDto
                {
                    Id = documento.Id,
                    URL = documento.Nombre,
                    FechaEmicion = documento.FechaEmicion,
                    FechaVencimiento = documento.FechaVencimiento,
                    EstadoId = documento.EstadoId,
                    ProveedorId = documento.ProveedorId,
                    CatalogoDocumentoId = documento.CatalogoDocumentoId,
                    FechaCreacion = documento.FechaCreacion,
                    FechaModificacion = documento.FechaModificacion,
                    CreadoPor = documento.CreadoPor,
                    ModificadoPor = documento.ModificadoPor
                };
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Documento encontrado",
                    StatusCode = 200,
                    Data = documentoDto
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Documento no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto InsertDocumento(Documento documento)
        {
            try
            {
                _repository.Insert(documento);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Documento insertado correctamente",
                    StatusCode = 200,
                    Data = documento
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Documento no insertado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto RemoveDocumento(int id)
        {
            try
            {
                Documento documento = _repository.GetById(id);
                _repository.Remove(documento);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Documento eliminado correctamente",
                    StatusCode = 200,
                    Data = documento
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Documento no eliminado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto UpdateDocumento(Documento documento)
        {
            try
            {
                _repository.Update(documento);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Documento actualizado correctamente",
                    StatusCode = 200,
                    Data = documento
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Documento no actualizado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }

        }


    }
}
