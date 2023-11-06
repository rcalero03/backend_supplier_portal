using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
    public  class ConfiguracionNotificacionDto
    {
        public int Id { get; set; }
        public int? Dias { get; set; }
        public TimeSpan? Hora { get; set; }
        public int EstadoId { get; set; }
        public int ? CreadoPor { get; set; }
        public DateTime ? FechaCreacion { get; set; }
        public int ? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
