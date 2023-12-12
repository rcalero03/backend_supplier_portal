using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Usuario : BaseEntity
    {
        public string ? Nombre { get; set; }
        public string? Email { get; set; }
        public int EstadoId { get; set; }
        public string? UserIdAzure { get; set; }
        public ICollection <RolUsuario> ? RolUsuarios { get; set; }
        public ICollection <Proveedor> ? Proveedores { get; set; }

        [ForeignKey("EstadoId")]
        public  Estado ? Estado { get; set; }

        //[NoMapper] BaseEntity

        public new DateTime? FechaCreacion { get; set; }
        public new DateTime? FechaModificacion { get; set; }
        public new int? CreadoPor { get; set; }
        public new int? ModificadoPor { get; set; }

    }
}
