using DomainLayer.Models;
using DomainLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceLayer.IServices
{
    public interface IConfiguracionGeneralService
    {
        IEnumerable<ConfiguracionGeneral> GetAllConfiguracionGenerales();
        ConfiguracionGeneralDto GetByCode(string code);
    }
}
