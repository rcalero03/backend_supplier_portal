using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/Ciudad")]
    [ApiController]
    public class CiudadController : Controller
    {
       private readonly ICiudadService _ciudadService;

        public CiudadController(ICiudadService ciudadService)
        {
            _ciudadService = ciudadService;
        }


        [HttpGet("{paisid}")]
        public IActionResult GetCiudadById(int paisid)
        {
            ResponseDto response = _ciudadService.GetCiudadById(paisid);
            return Ok(response);
        }

    }
}
