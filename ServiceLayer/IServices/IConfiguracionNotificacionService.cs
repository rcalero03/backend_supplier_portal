using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IConfiguracionNotificacionService
    {
        ResponseDto GetAllConfiguracionNotificacion();
        ResponseDto GetConfiguracionNotificacionById(int id);
        ResponseDto InsertConfiguracionNotificacion(ConfiguracionNotificacion ConfiguracionNotificacion);
        ResponseDto UpdateConfiguracionNotificacion(ConfiguracionNotificacion ConfiguracionNotificacion);
        ResponseDto RemoveConfiguracionNotificacion(int id);
    }
}
