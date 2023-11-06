using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/ConfiguracionNotificacion")]
    [ApiController]
    public class ConfiguracionNotificacionController : Controller
    {
        private readonly IConfiguracionNotificacionService _configuracionNotificacion;

        public ConfiguracionNotificacionController(IConfiguracionNotificacionService configuracionNotificacion)
        {
            _configuracionNotificacion = configuracionNotificacion;
        }

        [HttpGet]
        public IActionResult GetAllConfiguracionNotificacion()
        {
            ResponseDto response = _configuracionNotificacion.GetAllConfiguracionNotificacion();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetConfiguracionNotificacionById(int id)
        {
            ResponseDto response = _configuracionNotificacion.GetConfiguracionNotificacionById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult InsertConfiguracionNotificacion(ConfiguracionNotificacion configuracionNotificacion)
        {
            ResponseDto response = _configuracionNotificacion.InsertConfiguracionNotificacion(configuracionNotificacion);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateConfiguracionNotificacion(ConfiguracionNotificacion configuracionNotificacion)
        {
            ResponseDto response = _configuracionNotificacion.UpdateConfiguracionNotificacion(configuracionNotificacion);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult DeleteConfiguracionNotificacion(int id)
        {
            ResponseDto response = _configuracionNotificacion.RemoveConfiguracionNotificacion(id);
            return Ok(response);
        }

      
    }
}
