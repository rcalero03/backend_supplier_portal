using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class RolUsuario : BaseEntity
    {
        public int RolId { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("RolId")]
        public Rol ? Rol { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario ? Usuario { get; set; }

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
