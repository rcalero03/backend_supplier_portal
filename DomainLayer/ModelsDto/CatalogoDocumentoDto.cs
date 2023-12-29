using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
    public class CatalogoDocumentoDto
    {
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public string ? Descripcion { get; set;}
        public int ? Requerido { get; set; }
        public DateTime ? FechaCreacion { get; set; }
        public DateTime ? FechaModificacion { get; set; }
        public int ? CreadoPor { get; set; }
        public int ? ModificadoPor { get; set; }
        public int ? EstadoId { get; set; }
        public int ? TipoDocumentoId { get; set; }
        public string? TipoDocumentoName { get; set; }
    }
}
