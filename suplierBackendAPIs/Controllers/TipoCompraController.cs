using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/TipoCompra")]
    [ApiController]
    public class TipoCompraController : Controller
    {
        public readonly ITipoCompraService _tipoCompraService;

        public TipoCompraController(ITipoCompraService tipoCompraService)
        {
            _tipoCompraService = tipoCompraService;
        }

        [HttpGet]
        public IActionResult GetAllTipoCompras()
        {
            ResponseDto response = _tipoCompraService.GetAllTipoCompra();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetTipoCompraById(int id)
        {
            ResponseDto response = _tipoCompraService.GetTipoCompraById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult InsertTipoCompra(TipoCompra tipoCompra)
        {
            ResponseDto response = _tipoCompraService.InsertTipoCompra(tipoCompra);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateTipoCompra(TipoCompra tipoCompra)
        {
            ResponseDto response = _tipoCompraService.UpdateTipoCompra(tipoCompra);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTipoCompra(int id)
        {
            ResponseDto response = _tipoCompraService.RemoveTipoCompra(id);
            return Ok(response);
        }
    }
}
