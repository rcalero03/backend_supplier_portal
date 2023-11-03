using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : Controller
    {
        private readonly IPaisService _paisService;

        public PaisController(IPaisService paisService)
        {
            _paisService = paisService;
        }

        [HttpGet]
        public IActionResult GetAllPaises()
        {
            ResponseDto response = _paisService.GetAllPaises();
            return Ok(response);
        }
        
    }
}
