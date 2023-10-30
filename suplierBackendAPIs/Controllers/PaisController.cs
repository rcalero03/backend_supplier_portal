using DomainLayer.Models;
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
            return Ok(_paisService.GetAllPaises());
        }
        
    }
}
