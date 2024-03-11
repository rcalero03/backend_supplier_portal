using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Ocsp;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
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
        public readonly BlobServiceClient _blobClient;
        private readonly string AzureConection;


        public DocumentoService(IRepository<Documento> repository,
            IRepository<Usuario> usuarioRepository,
            IRepository<Estado> estadoRepository,
            IRepository<TipoDocumento> tipoDocumentoRepository,
            BlobServiceClient blob,
            IConfiguration configuration
           )
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _estadoRepository = estadoRepository;
            _tipoDocumentoRepository = tipoDocumentoRepository;
            string AzureConect = configuration["AzureConection"];
            _blobClient = new BlobServiceClient(AzureConect);
        }

        public BlobContainerClient GetContainer( string containerName )
        {
            BlobContainerClient container = _blobClient.GetBlobContainerClient( containerName );
            return container;
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
        public async Task<Stream> dowloadFileAure(string file, AzureDocumentoDTO azureConfig)
        {
            try
            {
                var blobServiceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=grupoccn;AccountKey=c4Lh+t6HRfrg+Wmqo8CBBmtP+fliVz0I+A4w55mqAaLg9ikFYymp/adYRwdrGm39tVsOnehzDJKL+AStbBdGwg==;EndpointSuffix=core.windows.net");
                var blobContainerClient = blobServiceClient.GetBlobContainerClient(azureConfig.containerName);
                var blobCliente = blobContainerClient.GetBlobClient(file);
                var response = await blobCliente.DownloadAsync();
                return response.Value.Content;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<ResponseDto> uploadAzureDocumento(IFormFile file, AzureDocumentoDTO azureConfig)
        {
            try
            {
                    Stream stream = file.OpenReadStream();
                    string fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + "_"+ file.FileName ;
                    BlobContainerClient container = GetContainer(azureConfig.containerName);
                    BlobClient blobClient = container.GetBlobClient(fileName);
                     await blobClient.UploadAsync(stream);

                    Uri blobUrl = blobClient.Uri;
                    string url = blobUrl.ToString();

                return new ResponseDto
                {
                    Success = true,
                    Message = "Documentos cargados correctamente en Azure",
                    StatusCode = 200,
                    Data = fileName
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = $"Error al cargar documentos: {ex.Message}",
                    StatusCode = 500,
                    Data = null
                };
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

        public async Task<ResponseDto> updateDocumenStatusRefusedAsync(StatusDocumentDto statusDocument)
        {
            Documento documento = new Documento();
            var usuario = new Usuario();
            var estado = new Estado();
            foreach (var document in _repository.GetAllAsQueryable().Include(x => x.Proveedor).Include(x => x.CatalogoDocumento).Where(x => x.Id == statusDocument.DocumentId))
            {
                documento = document;
            }
            if (documento != null)
            {
                usuario = _usuarioRepository.GetById(documento.Proveedor.UsuarioId);
                estado = _estadoRepository.GetAll().FirstOrDefault(x => x.Nombre == "Rechazado");

                documento.EstadoId = estado?.Id;
                _repository.Update(documento);

                DateTime fechadoc = Convert.ToDateTime(documento.FechaEmicion);
                DateTime fechaActual = DateTime.Now;
                TimeSpan diferecia = fechaActual - fechadoc;
                //numero de dias
                int dias = (int)diferecia.Days;

                var to = usuario.Email;
                var url = "https://portaldeproveedoresv2.ccn.local:8081";
                var from = "devopsproveedores@ccn.com.ni";
                var body = "Estimado proveedor: " + usuario.Nombre + ", código-" + usuario.UserIdAzure + "\n" +
                           "Le informamos que el documento " + documento?.CatalogoDocumento?.Nombre + " cargado en la página web de proveedores, ha sido rechazado por "+"\n"+"inconsistencias en el documento solicitado. \n" +
                           "favor revisar y adjuntar el documento correcto por medio de este enlace: " + url + "\n" +
                           "**Nota: No corregir su documento puede generar demoras en el proceso de su pago.**\n" +
                           "Este correo se ha generado en forma automática, por favor no responder.\n" +
                           "Atentamente,\nGrupo CCN";

                var apiUrl = "https://sdesarrollo02.ccn.com.ni/mailapp/api/v2/Email";

                // Realiza la solicitud POST a la API

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

                var client = new HttpClient(handler);

                using (client = new HttpClient())
                {
                    try
                    {
                        var content = new MultipartFormDataContent();
                        content.Add(new StringContent(to), "To");
                        content.Add(new StringContent(from), "From");
                        content.Add(new StringContent("CCN"), "DisplayName");
                        content.Add(new StringContent("DOCUMENTO RECHAZADO"), "Subject");
                        content.Add(new StringContent(body));

                        var response = await client.PostAsync(apiUrl, content);

                       

                        if (response.IsSuccessStatusCode)
                        {
                            ResponseDto responseDto = new ResponseDto
                            {
                                Success = true,
                                Message = "Documento rechazado de forma exitosa, Email enviado",
                                StatusCode = 200,
                                //Data = documento

                            };
                          
                            _repository.SaveChange();
                            return responseDto;

                        }
                        else
                        {

                            ResponseDto responseDto = new ResponseDto
                            {
                                Success = true,
                                Message = "Ha ocurrido un error al enviar el email",
                                StatusCode = 200,
                                //Data = documento
                            };
                            return responseDto;
                        }

                    }
                    catch (Exception ex)
                    {

                        ResponseDto responseDto = new ResponseDto
                        {
                            Success = true,
                            Message = "Ha ocurrido un error al enviar el Email",
                            StatusCode = 200,
                            //Data = documento
                        };
                        return responseDto;
                    }
                }

            }
            else
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Documento no encontrado",
                    StatusCode = 400,
                    //Data = documento
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
