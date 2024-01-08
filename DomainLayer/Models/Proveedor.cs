using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public  class Proveedor : BaseEntity
    {
        public string? Empresa { get; set; }
        public string? Descripcion { get; set; }
        public string? Identificacion { get; set; }
        public string? IdentificacionTipo { get; set; }
        public string? ContactoPrimario { get; set; }
        public string? ContactoSecundario { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? PaginaWeb { get; set; }
        public string? Movil { get; set; }
        public string? Idioma { get; set; }
        public string? Observacion { get; set; }
        public string? CodigoProveedorSap { get; set; }
        public int? Aspirante { get; set; }
        public virtual ICollection<Documento> ? Documentos { get; set; }
        public virtual ICollection<ProveedorCategoria> ? ProveedorCategorias { get; set; }
        public virtual ICollection<Referencia>? Referencias { get; set; }


        public int CiudadId { get; set; }
        public int UsuarioId { get; set; }
        public int EstadoId { get; set; }
        public int SubtipoCompraId { get; set; }

        [ForeignKey("CiudadId")]
        public Ciudad ? Ciudad { get; set; }

        [ForeignKey("EstadoId")]
        public Estado ? Estado { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        [ForeignKey("SubtipoCompraId")]
        public SubtipoCompra ? SubtipoCompra { get; set; }



       
    }
}
