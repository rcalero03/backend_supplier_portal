using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public  class Estado : BaseEntity
    {
        public string ? Nombre { get; set; }
        public virtual ICollection<TipoDocumento>? TipoDocumentos { get; set; }
  
    }
}
