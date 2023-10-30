using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface ICiudadService
    {
        IEnumerable<Ciudad> GetAllCiudades();
        List<CiudadDto> GetCiudadById(int paisId);
        void InsertCiudad(Ciudad ciudad);
        void UpdateCiudad(Ciudad ciudad);
        void RemoveCiudad(Ciudad ciudad);
    }
}
