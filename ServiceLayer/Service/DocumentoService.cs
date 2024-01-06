using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using ServiceLayer.Service;
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
        public readonly IRepository<Usuario> _usuarioRepository;
        public readonly IRepository<Estado> _estadoRepository;

        public DocumentoService(IRepository<Documento> repository, IRepository<Usuario> usuarioRepository, IRepository<Estado> estadoRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _estadoRepository = estadoRepository;
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

        public ResponseDto updateDocumenStatus(int documentId, int status)
        {
            try
            {
                //var documento = _repository.GetById(documentId);
                var documento = new Documento();
                var usuario = new Usuario();
                var estado = new Estado();
                foreach (var document in _repository.GetAllAsQueryable().Include(x => x.Proveedor).Include(x => x.CatalogoDocumento).Where(x => x.Id == documentId))
                {
                    documento = document;
                }

                if (documento != null)
                {
                    usuario = _usuarioRepository.GetById(documento.Proveedor.UsuarioId);
                    estado = _estadoRepository.GetById(status);
                    documento.EstadoId = status;
                    _repository.Update(documento);
                    _repository.SaveChange();

                    MailRequest mail = new MailRequest();

                    mail.Subject = "Test email";
                    mail.Email = usuario.Email;
                    mail.Body = "<!DOCTYPE html>" +
                                "<html lang=\"en\">" +
                                "<head>" +
                                    "<meta charset=\"UTF-8\">" +
                                    "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
                                    "<title>Document</title>" +
                                "</head>" +
                                "<body style=\"text-align: center;\">" +
                                    "<img src=\"https://www.ccn.com.ni/wp-content/uploads/2015/08/LogoVertical.png\" alt=\"ccn\" style=\"height: 200px; width: auto;\">" +
                                    "<h2>Hola "+documento.Proveedor.Empresa+"</h2>" +
                                    "<p>Se informa que el documento "+documento.CatalogoDocumento.Nombre+" ha pasado al estado de <strong>"+estado.Nombre+"</strong></p>" +
                                    "<p>Le invitamos que actualize el documento en el portal</p>" +
                                "</body>" +
                                "<footer style=\"background-color: rgb(89, 161, 255); position: absolute; bottom: 0; width: 100%; height: 50px;\">" +
                                    "<label style=\"color: white; font-size: 24px;\">Terminos y condiciones</label>" +
                                "</footer>" +
                                "</html>";

                    var EmailService = new EmailService();

                    EmailService.SendEmailAsynAsync(mail);

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
            catch(Exception ex)
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
