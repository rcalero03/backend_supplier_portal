using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
    public  class ProveedorDto
    {
        public int Id { get; set; }
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
        public int? Aspirante { get; set; }
        public string? CodigoProveedorSap { get; set; }
        public int UsuarioId { get; set; }
        public int EstadoId { get; set; }
        public int CiudadId { get; set; }
        public int SubtipoCompraId { get; set; }
        public int CategoriaId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int? CreadoPor { get; set; }
        public int? ModificadoPor { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public int? PaisId { get; set; }
        public int? TipoCompraId { get; set; }


    }
}
