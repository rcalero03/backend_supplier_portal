using Azure;
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
        ResponseDto GetAllPaises();
        ResponseDto GetPaisById(int id);
        Pais getPaisById(int Id);

    }
}
