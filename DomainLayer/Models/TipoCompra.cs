using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class TipoCompra : BaseEntity
    {
        public string ? TipoCompras { get; set; }
        public string ? Descripcion { get; set; }
        public int ? EstadoId { get; set; }
        public IEnumerable<SubtipoCompra> ? SubtipoCompras { get; set; }

        [ForeignKey("EstadoId")]
        public Estado ? Estado { get; set; }


    }
}
