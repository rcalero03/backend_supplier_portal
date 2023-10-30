using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public  class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime ? FechaCreacion { get; set; }
        public DateTime ? FechaModificacion { get; set; }
        public int ? CreadoPor { get; set; }
        public int ? ModificadoPor { get; set; }

    }
}
