using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ModelsDto
{
    public class loginDto
    {
        public string? LocalAccountId { get; set; }//USUARIO DE AZURE
        public string? Name { get; set; }//NOOMBRE DEL USUARIO
        public string? Username { get; set; }//EMAIL DEL USUARIO
        public bool isAdmin { get; set; } = false;//VALIDAR SI ES ADMINISTRADOR
    }
}
