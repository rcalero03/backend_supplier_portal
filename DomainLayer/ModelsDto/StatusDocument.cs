using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
    public class StatusDocument
    {
        public int DocumentoId { get; set; }
        public int EstadoId { get; set; }
        public string Observacion { get; set; }
    }
}
