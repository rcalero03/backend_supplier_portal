using DomainLayer.Models;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class EstadoService : IEstadoService
    {
        private IRepository<Estado> _repository;


        public EstadoService(IRepository<Estado> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Estado> GetAllEstados()
        {
            return _repository.GetAll();
            
        }

        public Estado GetEstadoById(int id)
        {
           return _repository.GetById(id);
        }

        public void InsertEstado(Estado estado)
        {
            //insertar registro estado
            _repository.Insert(estado);
            _repository.SaveChange();
        }

        public void UpdateEstado(Estado estado)
        {
            //actualizar registr de estado
            _repository.Update(estado);
            _repository.SaveChange();
        }

        public void RemoveEstado(int id)
        {
            Estado estado = _repository.GetById(id);
            _repository.Remove(estado);
               
        }
        
        public void RemoveEstado(Estado estado)
        {
            Estado estado1 = _repository.GetById(estado.Id);
            _repository.Remove(estado1);
            _repository.SaveChange();
        }
    }
}
