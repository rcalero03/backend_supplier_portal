﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class ConfiguracionNotificacion : BaseEntity
    {
        public int ? Dias { get; set; }
        public TimeSpan ? Hora { get; set; }
        public int EstadoId { get; set; }
        [ForeignKey("EstadoId")]
        public Estado ? Estado { get; internal set; }

    }
}
