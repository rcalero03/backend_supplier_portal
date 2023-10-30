using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class CatalogoDocumento : BaseEntity
    {
        public string ? Nombre { get; set; }
        public string ? Descripcion { get; set; }
        public int ? Requerido { get; set; }
        public int EstadoId { get; set; }
        public int TipoDocumentoId { get; set; }

        [ForeignKey("EstadoId")]
        public Estado ? Estados { get;  set; }
        [ForeignKey("TipoDocumentoId")]
        public TipoDocumento ? TipoDocumentos { get; set; }
    }
}
