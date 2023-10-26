using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Ciudad : BaseEntity
    {
        public string ? nombre { get; set; }

        public int ? PaisId { get; set; }

        public IEnumerable<Proveedor> ? Proveedores { get; set; }

        [ForeignKey("PaisId")]
        public Pais ? Pais { get; set; }

        //[NoMapper] BaseEntity
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
