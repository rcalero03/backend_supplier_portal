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
    public class ProveedorService : IProveedorService
    {
        public readonly IRepository<Proveedor> _repository;
        public readonly IRepository<TipoDocumento> _tipoDocumentoRepository;
     
        //ivate UsuarioService _repositoryUsuario;
        private Usuario usuario = new Usuario();
        private PaisService _repositoryPais;
        private TipoCompraService _repositoryTipoCompra;
        private SubtipoCompraService _repositorySubtipoCompra;
        private ICiudadService _repositoryCiudad;

        public ProveedorService(IRepository<Proveedor> repository, IRepository<TipoDocumento> tipoDocumentoRepository)
        {
            _repository = repository;
            _tipoDocumentoRepository = tipoDocumentoRepository;
        }

        public ResponseDto GetAllProveedor()
        {            
            try
            {
                IEnumerable<Proveedor> proveedores = _repository.GetAllAsQueryable()
                    .Include(x=>x.Ciudad).ThenInclude(c=>c.Pais)
                    .Include(x=>x.SubtipoCompra).ThenInclude(y=>y.TipoCompra)
                    .Include(x=>x.Usuario)
                    .Where(x=>x.EstadoId == 1)
                    .ToList();
                
                List<ProveedorDto> proveedorDto = new List<ProveedorDto>();
                foreach (var proveedor in proveedores)
                {
                    int IdDocumento = Convert.ToInt32(proveedor.IdentificacionTipo);
                    string TipoDocumentoName = _tipoDocumentoRepository.GetById(IdDocumento).Nombre.ToString();
                    
                        proveedorDto.Add(new ProveedorDto
                        {
                            Id = proveedor.Id,
                            Empresa = proveedor.Empresa,
                            Descripcion = proveedor.Descripcion,
                            Identificacion = proveedor.Identificacion,
                            IdentificacionTipo = TipoDocumentoName,
                            ContactoPrimario = proveedor.ContactoPrimario,
                            ContactoSecundario = proveedor.ContactoSecundario,
                            Direccion = proveedor.Direccion,
                            Telefono = proveedor.Telefono,
                            PaginaWeb = proveedor.PaginaWeb,
                            Movil = proveedor.Movil,
                            Idioma = proveedor.Idioma,
                            Observacion = proveedor.Observacion,
                            CodigoProveedorSap = proveedor.CodigoProveedorSap,
                            CiudadId = proveedor.CiudadId,
                            UsuarioId = proveedor.UsuarioId,
                            EstadoId = proveedor.EstadoId,
                            Aspirante = proveedor.Aspirante,
                            SubtipoCompraId = proveedor.SubtipoCompraId,
                            PaisId = proveedor.Ciudad?.PaisId,
                            TipoCompraId = proveedor.SubtipoCompra?.TipoCompraId,
                            CreadoPor = proveedor.CreadoPor,
                            ModificadoPor = proveedor.ModificadoPor,
                            PaisNombre = proveedor?.Ciudad?.Pais?.Nombre,
                            TipoCompraNombre = proveedor?.SubtipoCompra?.TipoCompra?.Descripcion,
                            CiudadNombre = proveedor?.Ciudad?.Nombre,
                            SubtipoCompraNombre = proveedor?.SubtipoCompra?.Descripcion,
                            EmailUsuario = proveedor?.Usuario?.Email,
                            FechaModificacion = (DateTime)proveedor.FechaModificacion,
                            FechaCreacion = (DateTime)proveedor.FechaCreacion,
                            IdentificacionTipoId = proveedor.IdentificacionTipo
                        });
                      
                }
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Proveedor encontrado",
                    StatusCode = 200,
                    Data = proveedorDto
                };
                return responseDto;
            }
                       catch (Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Proveedor no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

      

        public ResponseDto getSuppliersByUserId(int id)
        {
            try
            {

                 List<Proveedor> proveedores = _repository.GetAllAsQueryable().
                    Include(x => x.Ciudad).Include(x => x.SubtipoCompra).Where(x=>x.UsuarioId == id).ToList();
                List<ProveedorDto> proveedorDto = new List<ProveedorDto>();
                foreach (var proveedor in proveedores)
                {
                    ProveedorDto proveedorDto1 = new ProveedorDto()
                    {
                        Id = proveedor.Id,
                        Empresa = proveedor.Empresa,
                        Descripcion = proveedor.Descripcion,
                        Identificacion = proveedor.Identificacion,
                        IdentificacionTipo = proveedor.IdentificacionTipo,
                        ContactoPrimario = proveedor.ContactoPrimario,
                        ContactoSecundario = proveedor.ContactoSecundario,
                        Direccion = proveedor.Direccion,
                        Telefono = proveedor.Telefono,
                        PaginaWeb = proveedor.PaginaWeb,
                        Movil = proveedor.Movil,
                        Idioma = proveedor.Idioma,
                        Observacion = proveedor.Observacion,
                        CodigoProveedorSap = proveedor.CodigoProveedorSap,
                        CiudadId = proveedor.CiudadId,
                        UsuarioId = proveedor.UsuarioId,
                        EstadoId = proveedor.EstadoId,
                        Aspirante = proveedor.Aspirante,
                        SubtipoCompraId = proveedor.SubtipoCompraId,
                        PaisId = proveedor.Ciudad?.PaisId,
                        TipoCompraId = proveedor.SubtipoCompra?.TipoCompraId,
                        CreadoPor = proveedor.CreadoPor,
                        ModificadoPor = proveedor.ModificadoPor,
                    };
                    proveedorDto.Add(proveedorDto1);
                }
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Proveedor encontrado",
                    StatusCode = 200,
                    Data = proveedorDto
                };
                return responseDto;
            }
            catch (Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Proveedor no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto GetProveedorById(int id)
        {
            try
            {
                Proveedor proveedor = _repository.GetById(id);
                Proveedor proveedorDto = new Proveedor
                {
                    Id = proveedor.Id,
                    Empresa = proveedor.Empresa,
                    Descripcion = proveedor.Descripcion,
                    Identificacion = proveedor.Identificacion,
                    IdentificacionTipo = proveedor.IdentificacionTipo,
                    ContactoPrimario = proveedor.ContactoPrimario,
                    ContactoSecundario = proveedor.ContactoSecundario,
                    Direccion = proveedor.Direccion,
                    Telefono = proveedor.Telefono,
                    PaginaWeb = proveedor.PaginaWeb,
                    Movil = proveedor.Movil,
                    Idioma = proveedor.Idioma,
                    Observacion = proveedor.Observacion,
                    CodigoProveedorSap = proveedor.CodigoProveedorSap,
                    CiudadId = proveedor.CiudadId,
                    UsuarioId = proveedor.UsuarioId,
                    EstadoId = proveedor.EstadoId,
                    Aspirante = proveedor.Aspirante,
                    SubtipoCompraId = proveedor.SubtipoCompraId,
                    CreadoPor = proveedor.CreadoPor,
                    ModificadoPor = proveedor.ModificadoPor,
                };
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Proveedor encontrado",
                    StatusCode = 200,
                    Data = proveedorDto
                };
                return responseDto;
            }
            catch (Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Proveedor no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto InsertProveedor(Proveedor proveedor)
        {
            try
            {
                _repository.Insert(proveedor);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Proveedor insertado correctamente",
                    StatusCode = 200,
                    Data = proveedor
                };
                return responseDto;
            }
            catch (Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Proveedor no insertado",
                    StatusCode = 500,
                    Data = ex
                };
                return responseDto;
            }
        }

        public ResponseDto RemoveProveedor(int id)
        {
            try
            {
                Proveedor proveedor = _repository.GetById(id);
                _repository.Remove(proveedor);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Proveedor eliminado correctamente",
                    StatusCode = 200,
                    Data = proveedor
                };
                return responseDto;
            }
            catch (Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Proveedor no eliminado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto UpdateProveedor(Proveedor proveedor)
        {
            try
            {
                _repository.Update(proveedor);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Proveedor actualizado correctamente",
                    StatusCode = 200,
                    Data = proveedor
                };
                return responseDto;
            }
            catch (Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Proveedor no actualizado correctamente",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }



    }
}
