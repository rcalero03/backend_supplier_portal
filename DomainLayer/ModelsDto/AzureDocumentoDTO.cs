using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
    public  class AzureDocumentoDTO
    { 
        public string? accountName { get; set; }
        public string? containerName { get; set; }
        public string? sasToken { get; set; }
        public string? sasUrl { get; set; }
    }
}
