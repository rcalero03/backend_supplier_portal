using DomainLayer.Models;
using DomainLayer.ModelsDto;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class PaisService : IPaisService
    {
        private IRepository<Pais> _paisRepository;

        public PaisService(IRepository<Pais> paisRepository)
        {
            _paisRepository = paisRepository;
        }

        public List<PaisDto> GetAllPaises()
        {
            List<PaisDto> paisDtos = new List<PaisDto>();

            foreach (var pais in _paisRepository.GetAll())
            {
                // Crear un objeto PaisDto y asignar los valores
                PaisDto paisDto = new PaisDto
                {
                    nombre = pais.Nombre,
                    id = pais.Id
                };

                // Agregar el objeto PaisDto a la lista
                paisDtos.Add(paisDto);
            }

            return paisDtos;
        }

        public Pais GetPaisById(int id)
        {
            return _paisRepository.GetById(id);
        }

        public void InsertPais(Pais pais)
        {
            _paisRepository.Insert(pais);
            _paisRepository.SaveChange();
        }

        public void RemovePais(Pais pais)
        {
            var paisToRemove = _paisRepository.GetById(pais.Id);
            _paisRepository.Remove(paisToRemove);
            _paisRepository.SaveChange();
        }

        public void UpdatePais(Pais pais)
        {
            var paisToUpdate = _paisRepository.GetById(pais.Id);
            _paisRepository.Update(paisToUpdate);
            _paisRepository.SaveChange();
        }


    }
}
