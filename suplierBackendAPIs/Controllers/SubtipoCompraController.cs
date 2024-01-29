using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/SubtipoCompra")]
    [ApiController]
    [Authorize]
    public class SubtipoCompraController : Controller
    {
          private readonly ISubtipoCompraService _subtipoCompraService;
    
          public SubtipoCompraController(ISubtipoCompraService subtipoCompraService)
        {
                _subtipoCompraService = subtipoCompraService;
          }

        [HttpGet]
          public IActionResult GetAllSubtipoCompra()
        {
                ResponseDto responseDto = _subtipoCompraService.GetAllSubtipoCompra();
                return Ok(responseDto);
          }

        [HttpGet("{id}")]
          public IActionResult GetSubtipoCompraById(int id)
        {
                ResponseDto responseDto = _subtipoCompraService.GetSubtipoCompraById(id);
                return Ok(responseDto);
          }

        [HttpGet("getAllSubtipoCompraByTipoCompraId/{id}")]
        public IActionResult getSubtipoCompraByTipoCompraId(int id)
        {
                    ResponseDto responseDto = _subtipoCompraService.getSubtipoCompraByTipoCompraId(id);
                    return Ok(responseDto);
         }

        [HttpPost]
          public IActionResult AddSubtipoCompra(SubtipoCompra subtipoCompra)
        {
                ResponseDto responseDto = _subtipoCompraService.InsertSubtipoCompra(subtipoCompra);
                return Ok(responseDto);
          }

        [HttpPut]
          public IActionResult UpdateSubtipoCompra(SubtipoCompra subtipoCompra)
        {
                ResponseDto responseDto = _subtipoCompraService.UpdateSubtipoCompra(subtipoCompra);
                return Ok(responseDto);
          }

        [HttpDelete("{id}")]
          public IActionResult DeleteSubtipoCompra(int id)
        {
                ResponseDto responseDto = _subtipoCompraService.RemoveSubtipoCompra(id);
                return Ok(responseDto);
          } 
    }
}