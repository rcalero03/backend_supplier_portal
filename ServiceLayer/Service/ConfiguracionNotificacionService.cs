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
    public class ConfiguracionNotificacionService : IConfiguracionNotificacionService
    {
        private readonly IRepository<ConfiguracionNotificacion>  _repository;
        

        public ConfiguracionNotificacionService(IRepository<ConfiguracionNotificacion> repository)
        {
            _repository = repository;
           
        }

        public ResponseDto GetAllConfiguracionNotificacion()
        {
           try
            {
                IEnumerable<ConfiguracionNotificacion> ConfiguracionNotificacions = _repository.GetAll();
                List<ConfiguracionNotificacionDto> ConfiguracionNotificacionDto = new List<ConfiguracionNotificacionDto>();
                foreach (var ConfiguracionNotificacion in ConfiguracionNotificacions)
                {
                    ConfiguracionNotificacionDto.Add(new ConfiguracionNotificacionDto
                    {
                        Id = ConfiguracionNotificacion.Id,
                        Dias = ConfiguracionNotificacion.Dias,
                        Hora = ConfiguracionNotificacion.Hora,
                        EstadoId = ConfiguracionNotificacion.EstadoId,
                        FechaCreacion = ConfiguracionNotificacion.FechaCreacion,
                        FechaModificacion = ConfiguracionNotificacion.FechaModificacion,
                        CreadoPor = ConfiguracionNotificacion.CreadoPor,
                        ModificadoPor = ConfiguracionNotificacion.ModificadoPor
                    });
                }
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "ConfiguracionNotificacion encontrado",
                    StatusCode = 200,
                    Data = ConfiguracionNotificacionDto
                };
                return responseDto;
            }
            catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "ConfiguracionNotificacion no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto GetConfiguracionNotificacionById(int id)
        {
            try
            {
                ConfiguracionNotificacion ConfiguracionNotificacion = _repository.GetById(id);
                ConfiguracionNotificacionDto ConfiguracionNotificacionDto = new ConfiguracionNotificacionDto
                {
                    Id = ConfiguracionNotificacion.Id,
                    Dias = ConfiguracionNotificacion.Dias,
                    Hora = ConfiguracionNotificacion.Hora,
                    EstadoId = ConfiguracionNotificacion.EstadoId,
                    FechaCreacion = ConfiguracionNotificacion.FechaCreacion,
                    FechaModificacion = ConfiguracionNotificacion.FechaModificacion,
                    CreadoPor = ConfiguracionNotificacion.CreadoPor,
                    ModificadoPor = ConfiguracionNotificacion.ModificadoPor
                };
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "ConfiguracionNotificacion encontrado",
                    StatusCode = 200,
                    Data = ConfiguracionNotificacionDto
                };
                return responseDto;
            }
            catch
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "ConfiguracionNotificacion no encontrado",
                    StatusCode = 500,
                    Data = null
                };
                return responseDto;
            }
        }

        public ResponseDto InsertConfiguracionNotificacion(ConfiguracionNotificacion ConfiguracionNotificacion)
        {
            try
            {
                _repository.Insert(ConfiguracionNotificacion);
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "ConfiguracionNotificacion insertado correctamente",
                    StatusCode = 200,
                    Data = ConfiguracionNotificacion
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "ConfiguracionNotificacion no insertado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }

        }

        public ResponseDto UpdateConfiguracionNotificacion(ConfiguracionNotificacion ConfiguracionNotificacion)
        {
            try
            {
                _repository.Update(ConfiguracionNotificacion);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "ConfiguracionNotificacion actualizado correctamente",
                    StatusCode = 200,
                    Data = ConfiguracionNotificacion
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "ConfiguracionNotificacion no actualizado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }

        public ResponseDto RemoveConfiguracionNotificacion(int id)
        {
            try
            {
                ConfiguracionNotificacion ConfiguracionNotificacion = _repository.GetById(id);
                _repository.Remove(ConfiguracionNotificacion);
                _repository.SaveChange();
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "ConfiguracionNotificacion eliminado correctamente",
                    StatusCode = 200,
                    Data = ConfiguracionNotificacion
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "ConfiguracionNotificacion no eliminado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
        }
    }
}
