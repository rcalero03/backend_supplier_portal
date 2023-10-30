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
    public  class CiudadService : ICiudadService
    {
        private IRepository<Ciudad> _repository;

        public CiudadService(IRepository<Ciudad> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Ciudad> GetAllCiudades()
        {
            return _repository.GetAll();
        }

        public List<CiudadDto> GetCiudadById(int paisId)
        {
            List<CiudadDto> ciudadDtos = new List<CiudadDto>();

            foreach (var item in GetAllCiudades())
            {
                if(item.PaisId == paisId)
                {
                    CiudadDto countryDto = new CiudadDto
                    {
                        Id = item.Id,
                        Nombre = item.Nombre == null ? string.Empty : item.Nombre
                    };

                    ciudadDtos.Add(countryDto);

                }

            }
            return ciudadDtos;

        }


        public void InsertCiudad(Ciudad ciudad)
        {
            _repository.Insert(ciudad);
            _repository.SaveChange();
        }

        public void RemoveCiudad(Ciudad ciudad)
        {
            var ciudadToRemove = _repository.GetById(ciudad.Id);
            _repository.Remove(ciudadToRemove);
            _repository.SaveChange();
        }

        public void UpdateCiudad(Ciudad ciudad)
        {
            var ciudadToUpdate = _repository.GetById(ciudad.Id);
            _repository.Update(ciudadToUpdate);
            _repository.SaveChange();
        }

    }
}
