using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class ProveedorCategoria : BaseEntity
    {
        public Proveedor ? Proveedor { get; set; }
        public Categoria ? Categoria { get; set; }
        public Estado ? Estado { get; set; }

        [ForeignKey("ProveedorId")]
        public int ? ProveedorId { get; set; }
        [ForeignKey("CategoriaId")]
        public int ? CategoriaId { get; set; }
        [ForeignKey("EstadoId")]
        public int ? EstadoId { get; set; }


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
