using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/Proveedor")]
    [ApiController]
    [Authorize]
    public class ProveedorController : Controller
    { 
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public IActionResult GetAllProveedor()
        {
            ResponseDto response = _proveedorService.GetAllProveedor();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetProveedorById(int id)
        {
            ResponseDto  response = _proveedorService.GetProveedorById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult InsertProveedor(Proveedor proveedor)
        {
            ResponseDto response = _proveedorService.InsertProveedor(proveedor);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateProveedor(Proveedor proveedor)
        {
            ResponseDto response =_proveedorService.UpdateProveedor(proveedor);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProveedor(int id)
        {
            ResponseDto response = _proveedorService.RemoveProveedor(id);
            return Ok(response);
        }

        [HttpGet("getSuppliersByUserId/{id}")]
        public IActionResult getSuppliersByUserId(int id)
        {
            ResponseDto response = _proveedorService.getSuppliersByUserId(id);
            return Ok(response);
        }


    }
}
