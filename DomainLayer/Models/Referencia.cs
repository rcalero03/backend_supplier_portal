using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Referencia : BaseEntity    
    {
        public string? Nombre { get; set; }
        public string ? Descripcion { get; set; }
        public string ? Contacto { get; set; }
        public DateTime Fecha { get; set; }
        public string ? Telefono { get; set; }
        public int ? DocumentoId { get; set; }
        public int ? EstadoId { get; set; }

        [ForeignKey("DocumentoId")]
        public Documento ? Documento { get; set; }
        [ForeignKey("EstadoId")]
        public Estado ? Estado { get; set; }
    }
}
