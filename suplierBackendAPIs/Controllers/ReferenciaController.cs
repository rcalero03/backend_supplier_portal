using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/Referencia")]
    [ApiController]
    public class ReferenciaController : Controller
    {
        private readonly IReferenciaService _referenciaService;

        public ReferenciaController(IReferenciaService referenciaService)
        {
            _referenciaService = referenciaService;
        }

        [HttpGet]
        public IActionResult GetAllReferencias()
        {
           ResponseDto response = _referenciaService.GetAllReferencias();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetReferenciaById(int id)
        {
            ResponseDto response = _referenciaService.GetReferenciaById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult InsertReferencia(Referencia referencia)
        {
            ResponseDto response = _referenciaService.InsertReferencia(referencia);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateReferencia(Referencia referencia)
        {
            ResponseDto response = _referenciaService.UpdateReferencia(referencia);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReferencia(int id)
        {
            ResponseDto response = _referenciaService.RemoveReferencia(id);
            return Ok(response);
        }
       
    }
}
