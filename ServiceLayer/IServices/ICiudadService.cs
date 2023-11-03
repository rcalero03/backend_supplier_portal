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
        ResponseDto GetCiudadById(int paisId);
       
    }
}
