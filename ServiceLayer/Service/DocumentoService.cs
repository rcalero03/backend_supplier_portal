using Azure;
using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ServiceLayer.Service
{
    public class DocumentoService : IDocumentoService
    {
        public readonly IRepository<Documento> _repository;
        public readonly IRepository<Usuario> _usuarioRepository;
        public readonly IRepository<Estado> _estadoRepository;
        public readonly IRepository<TipoDocumento> _tipoDocumentoRepository;

        public DocumentoService(IRepository<Documento> repository,
            IRepository<Usuario> usuarioRepository ,
            IRepository<Estado> estadoRepository,
            IRepository<TipoDocumento> tipoDocumentoRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _estadoRepository = estadoRepository;
            _tipoDocumentoRepository = tipoDocumentoRepository;
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

        public ResponseDto getAllDocumentoSupplierActive(int proveedorId)
        {
            try
            {
                List<DocumentoDto> documentoDto = new List<DocumentoDto>();
                IEnumerable<Documento> documentos = _repository.GetAll().Where(x => x.ProveedorId == proveedorId && x.EstadoId == 3 
                                                     || x.EstadoId == 4 || x.EstadoId == 5 || x.EstadoId==6);
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

        public ResponseDto updateStatusDocumentAproved(int IdDocument)
        {
            try
            {
                Documento documento = new Documento();
                var estado = new Estado();
                estado = _estadoRepository.GetAll().FirstOrDefault(x => x.Nombre == "Aprobado");
                documento = _repository.GetById(IdDocument);

                documento.EstadoId = estado?.Id;

                _repository.Update(documento);
                _repository.SaveChange();

                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Estado del documento actualizado correctamente",
                    StatusCode = 200,
                    //Data = documento
                };

                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = 500
                };
                return response;
            }
        }

  

        public ResponseDto updateDocumenStatusRefused(StatusDocumentDto statusDocument)
        {
            try
            {
                //var documento = _repository.GetById(documentId);
                var documento = new Documento();
                var usuario = new Usuario();
                var estado = new Estado();
                foreach (var document in _repository.GetAllAsQueryable().Include(x => x.Proveedor).Include(x => x.CatalogoDocumento).Where(x => x.Id == statusDocument.DocumentId))
                {
                    documento = document;
                }

                if (documento != null)
                {
                    usuario = _usuarioRepository.GetById(documento.Proveedor.UsuarioId);
                    estado = _estadoRepository.GetById(statusDocument.EstadoId);
                    documento.EstadoId = statusDocument.EstadoId;
                    documento.Observacion = statusDocument.Observacion;
                    _repository.Update(documento);
                    _repository.SaveChange();

                    MailRequestDto mail = new MailRequestDto();

                    var statusMessage = estado.Nombre == "Aprobado" ? "por lo tanto no se requieren realizar mas acciones." :
                        estado.Nombre == "Rechazado" ? "por inconsistencias en el documento solicitado, favor revisar y adjuntar el documento correcto " +
                        "por medio de este enlace: <a href=\"http://localhost:4200/pages/suppliers-module\">Adjuntar documento</a>" : "";
                    var nota = estado.Nombre == "Rechazado" ? "<p>**Nota: No corregir su documento puede generar demoras en el proceso de su pago. **</p>" : "";
                    var observacion = documento.Observacion;

                    mail.Subject = "Test email";
                    mail.Email = usuario.Email;
                    mail.Body = "<!DOCTYPE html>" +
                                "<html lang=\"en\"> " +
                                    "<head>" +
                                        "<meta charset=\"UTF-8\">" +
                                        "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
                                        "<title></title>" +
                                    "</head>" +
                                    "<body style=\"text-align: justify;\">" +
                                        "<div style=\"width: 90%; height: auto; border: gray 2px solid; font-family: sans-serif; padding: 20px; margin-left: 2.5%;\">" +
                                            "<p>" +
                                                "Estimado proveedor <span style=\"color: red\">" + usuario.Nombre + "</span>, codigo <span style=\"color: red\">" + documento.Proveedor.CodigoProveedorSap + "</span> <br><br>" +
                                                "Le informamos que el documento &quot;<span style=\"color: rgb(57, 150, 249); font-style: oblique;\">" + documento.CatalogoDocumento.Nombre + "</span>&quot; cargado en la pagina " +
                                                "web de proveedores ha sido <strong>" + estado.Nombre + "</strong> " + statusMessage +
                                            "</p>" +
                                                nota +
                                            "</p>" +
                                            "<p>" +
                                                "Observación del rechazo: <strong>" + observacion + "</strong>" +
                                            "</p>" +
                                            "<p>" +
                                                "Este correo es generado en forma automatica, favor no responder." +
                                            "</p>" +
                                            "<p>" +
                                                "Atentamente, <br><br>" +
                                                "Grupo CCN" +
                                            "</p>" +
                                        "</div>" +
                                    "</body>" +
                                "</html>";

                    var EmailService = new EmailService();

                    EmailService.SentEmailAsync(mail);

                    ResponseDto responseDto = new ResponseDto
                    {
                        Success = true,
                        Message = "Estado del documento actualizado correctamente",
                        StatusCode = 200,
                        //Data = documento
                    };

                    return responseDto;

                }
                else
                {
                    ResponseDto responseDto = new ResponseDto
                    {
                        Success = false,
                        Message = "Documento no encontrado",
                        StatusCode = 500,
                        //Data = documento
                    };

                    return responseDto;
                }
            }
            catch (Exception ex)
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

        public  ResponseDto reportDocument(ReportDocumentDto reportDocument)
        {
            IEnumerable<Documento> documentos = _repository.GetAllAsQueryable().
                Include(x=>x.Proveedor).ThenInclude(y=>y.Usuario)
                .Include(y=>y.CatalogoDocumento).ThenInclude(y => y.TipoDocumento)
                .Include(x=>x.Estados)
                .Where(x=>x.EstadoId == reportDocument.EstadoId && x.ProveedorId == reportDocument.ProveedorId);

            List<DocumentoDto> documentoDtos = new List<DocumentoDto>();

            foreach (Documento documento in documentos)
            {
                
                documentoDtos.Add(new DocumentoDto
                {
                    Id = documento.Id,
                    URL = documento.Nombre,
                    FechaEmicion = documento.FechaEmicion,
                    FechaVencimiento = documento.FechaVencimiento,
                    Observacion = documento.Observacion,
                    EstadoId = documento.EstadoId,
                    ProveedorId = documento.ProveedorId,
                    CatalogoDocumentoId = documento.CatalogoDocumentoId,
                    FechaCreacion = documento.FechaCreacion,
                    FechaModificacion = documento.FechaModificacion,
                    CreadoPor = documento.CreadoPor,
                    ModificadoPor = documento.ModificadoPor,
                    TipoDocumento = documento.CatalogoDocumento.TipoDocumento.Nombre,
                    CatalogoDocumentoNombre = documento.CatalogoDocumento.Nombre,
                    EstadoNomobre = documento.Estados.Nombre,
                    ProveedorNombre = documento.Proveedor.Usuario.Nombre,
                });
            }
            if(documentoDtos == null || documentoDtos.Count == 0){
                var mensaje = "No se encontraron registros";
            }

            ResponseDto responseDto = new ResponseDto
            {
                Success = true,
                Message = documentoDtos == null || documentoDtos.Count == 0 ? "No se encontro registro" : "Registros Encontrados",
                StatusCode = 200,
                Data = documentoDtos
            };

            return responseDto;
        }



    }
}
