using DomainLayer.Models;
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
            return Ok(_categoriaService.GetAllCategorias());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoriaById(int id)
        {
            return Ok(_categoriaService.GetCategoriaById(id));
        }

        [HttpPost]
        public IActionResult InsertCategoria(Categoria categoria)
        {
            _categoriaService.InsertCategoria(categoria);
            var response = new {
                status = 200,
                message = "Categoria creada correctamente" };
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateCategoria(Categoria categoria)
        {
            _categoriaService.UpdateCategoria(categoria);
            var response = new
            {
                status = 200,
                message = "Categoria actualizada correctamente"
            };
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria(int id)
        {
            _categoriaService.DeleteCategoria(id);
            return Ok();
        }





    }
}
