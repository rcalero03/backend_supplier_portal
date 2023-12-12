using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public  class Estado : BaseEntity
    {

        public string ? Nombre { get; set; }
        public virtual ICollection<TipoDocumento> ? TipoDocumentos { get; set; }
        public virtual ICollection<CatalogoDocumento> ? CatalogoDocumentos { get; set; }
        public virtual ICollection<ConfiguracionNotificacion> ? ConfiguracionNotificaciones { get; set; }
        public virtual ICollection<ConfiguracionGeneral>? ConfiguracionGeneral { get; set; }
        public virtual ICollection<Usuario> ? Usuarios { get; set; }
        public virtual ICollection<TipoCompra> ? TipoCompras { get; set; }
        public virtual ICollection<Categoria> ? Categorias { get; set; }
        public virtual ICollection<Proveedor> ? Proveedores { get; set; }
        public virtual ICollection<Documento> ? Documentos { get; set; }
        public virtual ICollection<Referencia> ? Referencias { get; set; }


        [NotMapped]
        public new DateTime ? FechaCreacion { get; set; }
        [NotMapped]
        public new DateTime ? FechaModificacion { get; set; }
        [NotMapped]
        public new int ? CreadoPor { get; set; }
        [NotMapped]
        public new int ? ModificadoPor { get; set; }

    }
}
