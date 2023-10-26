using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Pais : BaseEntity
    {
        public string ? Nombre { get; set; }

        public IEnumerable<Ciudad> ? Ciudades { get; set; }

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
