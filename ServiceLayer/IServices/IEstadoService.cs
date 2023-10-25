using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IEstadoService
    {
        IEnumerable<Estado> GetAllEstados();
        Estado GetEstadoById(int id);
        void InsertEstado(Estado estado);
        void UpdateEstado(Estado estado);
        void RemoveEstado(Estado estado);

    }
}
