using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Documento : BaseEntity
    {
        public string ? Nombre { get; set; }
        public DateTime ? FechaEmicion { get; set; }
        public DateTime ? FechaVencimiento { get; set; }
        public int ? EstadoId { get; set; }
        public int ? ProveedorId { get; set; }
        public int ? CatalogoDocumentoId { get; set; }

        [ForeignKey("CatalogoDocumentoId")]
        public CatalogoDocumento ? CatalogoDocumento { get; set; }
        [ForeignKey("EstadoId")]
        public Estado ? Estados { get; set; }
        [ForeignKey("ProveedorId")]
        public Proveedor ? Proveedor { get; set; }

    }
}
