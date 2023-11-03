using DomainLayer.Models;
using DomainLayer.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace supplierBackendAPIs.Controllers
{
    [Route("api/Categoria")]
    [ApiController]
    public class CategoriaController : Controller
    {
      private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult GetAllCategorias()
        {
            ResponseDto response = _categoriaService.GetAllCategorias();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoriaById(int id)
        {
          
            ResponseDto  response = _categoriaService.GetCategoriaById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult InsertCategoria(Categoria categoria)
        {
          
            ResponseDto response = _categoriaService.InsertCategoria(categoria);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateCategoria(Categoria categoria)
        {
           
            ResponseDto response =_categoriaService.UpdateCategoria(categoria);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria(int id)
        {
           ResponseDto response = _categoriaService.DeleteCategoria(id);
            return Ok(response);
        }





    }
}
