using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class SubtipoCompra : BaseEntity
    {
        public string ? Descripcion { get; set; }
        public int TipoCompraId { get; set; }
        public ICollection<Proveedor> ? Proveedores { get; set; }


        [ForeignKey("TipoCompraId")]
        public TipoCompra ? TipoCompra { get; set; }


        [NotMapped]
        public new DateTime? FechaCreacion { get; set; }
        [NotMapped] 
        public new DateTime? FechaModificacion { get; set; }
        [NotMapped]
        public new int? CreadoPor { get; set; }
        [NotMapped]
        public new int? ModificadoPor { get; set; }

    }
}
