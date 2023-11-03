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

        public ResponseDto GetCiudadById(int paisId)
        {
            try
            {
                List<CiudadDto> ciudadDtos = new List<CiudadDto>();

                foreach (var item in GetAllCiudades())
                {
                    if (item.PaisId == paisId)
                    {
                        CiudadDto countryDto = new CiudadDto
                        {
                            Id = item.Id,
                            Nombre = item.Nombre == null ? string.Empty : item.Nombre
                        };

                        ciudadDtos.Add(countryDto);

                    }

                }
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "Lista de ciudades por pais",
                    StatusCode = 200,
                    Data = ciudadDtos
                };
                return response;

            }catch(Exception e)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "Error al obtener la lista de ciudades por pais",
                    StatusCode = 500,
                    Data = e.Message
                };
                return response;
            }

        }

    }
}
