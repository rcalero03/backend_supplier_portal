using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : Controller
    {
       private readonly ICiudadService _ciudadService;

        public CiudadController(ICiudadService ciudadService)
        {
            _ciudadService = ciudadService;
        }


        [HttpGet("{id}")]
        public IActionResult GetCiudadById(int id)
        {
            return Ok(_ciudadService.GetCiudadById(id));
        }

    }
}
