using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IPaisService
    {
        List<PaisDto> GetAllPaises();
        Pais GetPaisById(int id);
        void InsertPais(Pais pais);
        void UpdatePais(Pais pais);
        void RemovePais(Pais pais);

    }
}
