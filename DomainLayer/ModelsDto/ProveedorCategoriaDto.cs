using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
    public class ProveedorCategoriaDto
    {
        public int Id { get; set; }
        public int ? ProveedorId { get; set; }
        public int ? CategoriaId { get; set; }
        public string? Proveedor { get; set; }
        public string? Categoria { get; set; }

    }
}
