using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public  class TipoDocumento : BaseEntity
    {
        public string ? Nombre { get; set; }
        public string ? Descripcion { get; set; }
        public int EstadoId { get; set; }

        public  Estado ? Estado { get; set; }
    }
}
