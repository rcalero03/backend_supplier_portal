﻿using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
   public class SubtipoCompraDto
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int TipoCompraId { get; set; }
        public string? TipoCompras { get; set; }
        public string? Usuario { get; set; }

    }
}
