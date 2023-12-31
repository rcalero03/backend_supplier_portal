﻿using DomainLayer.Models;
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
        private UsuarioService _repositoryUsuario;
        private Usuario usuario = new Usuario();
        private SubtipoCompraService _repositorySubtipoCompra;
        private ICiudadService _repositoryCiudad;

        public ProveedorService(IRepository<Proveedor> repository)
        {
            _repository = repository;
        }

        public ResponseDto GetAllProveedor()
        {            
            try
            {
                IEnumerable<Proveedor> proveedores = _repository.GetAll();
                List<Proveedor> proveedorDto = new List<Proveedor>();
                foreach (var proveedor in proveedores)
                {
                    proveedorDto.Add(new Proveedor
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
                        SubtipoCompraId = proveedor.SubtipoCompraId
                        
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
