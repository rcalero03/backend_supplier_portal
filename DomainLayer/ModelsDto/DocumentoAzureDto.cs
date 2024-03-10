﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
    public class DocumentoAzureDto
    {
        public IFormFile file {  get; set; }
        public DateTime? FechaEmicion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string? Observacion { get; set; }
        public int? EstadoId { get; set; }
        public int? ProveedorId { get; set; }
        public int? CatalogoDocumentoId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? CreadoPor { get; set; }
        public int? ModificadoPor { get; set; }
        public bool ? IsNew { get; set; }

    }
}