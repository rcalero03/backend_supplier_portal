using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
    public class StatusDocumentDto
    {
        public int DocumentId { get; set; }
        public int EstadoId { get; set; }
        public string? Observacion { get; set; }
    }
}
