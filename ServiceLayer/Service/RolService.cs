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
    public class RolService : IRolService
    {
        private IRepository<Rol> _repository;

        public RolService()
        {
        }

        public RolService(
            IRepository<Rol> repository
         )
        {
            _repository = repository;
        }

        public Rol GetByCode(string codigo)
        {
            return _repository.GetAll().FirstOrDefault(x => x.Codigo == codigo) ?? null;
        }
    }
}
