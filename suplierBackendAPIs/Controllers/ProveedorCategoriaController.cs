using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/ProveedorCategoria")]
    [ApiController]
    [Authorize]
    public class ProveedorCategoriaController : Controller
    {
        private readonly IProveedorCategoriaService _proveedorCategoriaService;

        public ProveedorCategoriaController(IProveedorCategoriaService proveedorCategoriaService)
        {
            _proveedorCategoriaService = proveedorCategoriaService;
        }

        [HttpGet]
        public IActionResult GetAllProveedorCategoria()
        {
            ResponseDto response = _proveedorCategoriaService.GetAllProveedorCategoria();
            return Ok(response);
        }

        [HttpGet("bySuppliers/{proveedorId}")]
        public IActionResult GetProveedorCategoriaByProveedorId(int proveedorId)
        {
            ResponseDto response = _proveedorCategoriaService.GetProveedorCategoriaByProveedorId(proveedorId);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult InsertProveedorCategoria(ProveedorCategoria proveedorCategoria)
        {
            ResponseDto response = _proveedorCategoriaService.InsertProveedorCategoria(proveedorCategoria);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateProveedorCategoria(ProveedorCategoria proveedorCategoria)
        {
            ResponseDto response = _proveedorCategoriaService.UpdateProveedorCategoria(proveedorCategoria);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProveedorCategoria(int id)
        {
            ResponseDto response = _proveedorCategoriaService.RemoveProveedorCategoria(id);
            return Ok(response);
        }
    }
}
