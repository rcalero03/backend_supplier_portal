using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class JobService : IJobService
    {
        private readonly IRepository<ConfiguracionNotificacion> _repositoryConfiguracionNotificacion;
        private readonly IRepository<Documento> _repositoryDocumento;
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IRepository<Estado> _estadoRepository;

        public JobService() { 
        }

        public  JobService(IRepository<ConfiguracionNotificacion> repositoryConfiguracionNotificacion,
                          IRepository<Documento> repositoryDocumento,
                          IRepository<Usuario> usuarioRepository,
                          IRepository<Estado> estadoRepository)
        {
            _repositoryConfiguracionNotificacion = repositoryConfiguracionNotificacion;
            _repositoryDocumento = repositoryDocumento;
            _usuarioRepository = usuarioRepository;
            _estadoRepository = estadoRepository;
        }

        public void ValidDocumentEmailAsync()
        {
            pruebaCorreo();
           List<Documento> documentos = _repositoryDocumento.GetAll().ToList();
           List<ConfiguracionNotificacion> configuracions = _repositoryConfiguracionNotificacion.GetAll().OrderBy(conf => conf.Dias).ToList();

           if (documentos != null && documentos.Count > 0 && configuracions != null && configuracions.Count > 0)
           {
               DateTime fechaActual = DateTime.Now;
               Console.WriteLine(fechaActual.ToString());

               foreach (var documento in documentos)
               {
                   DateTime fechadoc = Convert.ToDateTime(documento.FechaVencimiento);
                   TimeSpan diferecia = fechadoc - fechaActual;
                   //numero de dias
                   int dias = (int)diferecia.Days;

                   if (dias <= 0)
                   {
                       Console.WriteLine("Documento ha expirado: " + dias.ToString());
                      //_ = DocumentToExpiredAsync(documento.Id);
                   }
                   else if (dias > 0)
                   {
                    
                       var configuracion = configuracions.FirstOrDefault(conf => conf.Dias == dias);

                       if (configuracion != null)
                       {
                           Console.WriteLine("dias a expirar :" + dias.ToString());
                           // Aquí deberías tener lógica para enviar un correo electrónico en lugar de escribir en la consola
                           Console.WriteLine($"Enviar Email para {documento.Nombre}");
                       }
                   }
               }
           }


        }

        public async Task pruebaCorreo()
        {
            var to = "joseacajina85@gmail.com";
            var url = "https://portaldeproveedoresv2.ccn.local:8081";
            var from = "devopsproveedores@ccn.com.ni";
            var body = "Estimado proveedor Heyling González, código- 5860 \r\n" +
                "Le informamos que el documento “Constancia de no retención 2% julio 2022” cargado en la página web de proveedores, ha vencido, le \r\n" +
                "solicitamos adjuntar el documento vigente, usando el siguiente vínculo: Adjuntar documento. \r\n" +
                "**Nota: No corregir su documento puede generar demoras en el proceso de su pago. ** \r\n" +
                "Este correo se ha generado en forma automática, por favor no responder. \r\n" +
                "Atentamente, \r\n" +
                "Grupo CCN ";

            var apiUrl = "https://sdesarrollo02.ccn.com.ni/mailapp/api/v2/Email";

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
                    content.Add(new StringContent("DOCUMENTO A DIAS DE EXPIRAR"), "Subject");
                    content.Add(new StringContent(body), "body");

                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("La solicitud fue exitosa");
                    }
                    else
                    {
                        Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al realizar la solicitud: {ex.Message}");
                }
            }


        }


        public async Task DocumentToExpiredAsync(int IdDocument)
        {
            Documento documento = new Documento();
            var usuario = new Usuario();
            var estado = new Estado();
            foreach (var document in _repositoryDocumento.GetAllAsQueryable().Include(x => x.Proveedor).Include(x => x.CatalogoDocumento).Where(x => x.Id == IdDocument))
            {
                documento = document;
            }
            if (documento != null)
            {
                usuario = _usuarioRepository.GetById(documento.Proveedor.UsuarioId);
                estado = _estadoRepository.GetAll().FirstOrDefault(x => x.Nombre == "Expirado");

                DateTime fechadoc = Convert.ToDateTime(documento.FechaEmicion);
                DateTime fechaActual = DateTime.Now;
                TimeSpan diferecia = fechaActual - fechadoc;
                //numero de dias
                int dias = (int)diferecia.Days;

                var to = usuario.Email;
                var url = "https://portaldeproveedoresv2.ccn.local:8081";
                var from = "devopsproveedores@ccn.com.ni";
                var body = "Estimado proveedor: " +usuario.Nombre+ ", código-"+usuario.UserIdAzure+"\r\nLe informamos que el documento "+documento?.CatalogoDocumento?.Nombre+" cargado en" +
                    " la página web de proveedores,esta a punto e vencer, le\r\nsolicitamos adjuntar el documento vigente, usando el siguiente vínculo:"+url+"\r\n**Nota:" +
                    " No corregir su documento puede generar demoras en el proceso de su pago. **\r\nEste correo se ha generado en forma automática, por favor no responder." +
                    "\r\nAtentamente,\r\nGrupo CCN ";

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
                        content.Add(new StringContent("DOCUMENTO A DIAS DE EXPIRAR"), "Subject");
                        content.Add(new StringContent(body));

                        var response = await client.PostAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("La solicitud fue exitosa");
                        }
                        else
                        {
                            Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al realizar la solicitud: {ex.Message}");
                    }
                }

            }
        }

        public async Task updateDocumentStatusExpired(int IdDocument)
        {
            Documento documento = new Documento();
            var usuario = new Usuario();
            var estado = new Estado();
            foreach (var document in _repositoryDocumento.GetAllAsQueryable().Include(x => x.Proveedor).Include(x => x.CatalogoDocumento).Where(x => x.Id == IdDocument))
            {
                documento = document;
            }
            if (documento != null)
            {
                usuario = _usuarioRepository.GetById(documento.Proveedor.UsuarioId);
                estado = _estadoRepository.GetAll().FirstOrDefault(x => x.Nombre == "Expirado");
                documento.Observacion = "Documento Expirado";
                documento.EstadoId = estado?.Id;
                _repositoryDocumento.Update(documento);
                _repositoryDocumento.SaveChange();

                var to = usuario.Email;
                var url = "https://portaldeproveedoresv2.ccn.local:8081";
                var from = "devopsproveedores@ccn.com.ni";
                var body = "Estimado proveedor: " + usuario.Nombre + ", código-" + usuario.UserIdAzure + "\r\n Le informamos que el documento " + documento?.CatalogoDocumento?.Nombre + " cargado en" +
                    " la página web de proveedores, ha vencido , le\r\n solicitamos adjuntar el documento vigente, usando el siguiente vínculo:" + url + "\r\n **Nota:" +
                    " No corregir su documento puede generar demoras en el proceso de su pago. **\r\n Este correo se ha generado en forma automática, por favor no responder." +
                    "\r\n Atentamente,\r\n Grupo CCN ";

                Console.WriteLine(body);

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
                        content.Add(new StringContent("DOCUMENTO A DIAS DE EXPIRAR"), "Subject");
                        content.Add(new StringContent(body));

                        var response = await client.PostAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("La solicitud fue exitosa");
                        }
                        else
                        {
                            Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al realizar la solicitud: {ex.Message}");
                    }
                }

            }


        }

    }
}
