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

        public ResponseDto GetAllPaises()
        {
            try
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
                ResponseDto response = new ResponseDto
                {
                   Success= true,
                   Message = "Paises encontrados",
                   StatusCode = 200,
                   Data = paisDtos
                };
                return response;    
            }catch(Exception e)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "Error al obtener los paises",
                    StatusCode = 500,
                    Data = e.Message
                };
                return response;
            }
        }

        public ResponseDto GetPaisById(int id)
        {
            try
            {
                Pais pais = _paisRepository.GetById(id);
                PaisDto paisDto =  new PaisDto
                {
                    nombre = pais.Nombre,
                    id = pais.Id
                };
                ResponseDto response = new ResponseDto
                {
                    Success = true,
                    Message = "Pais encontrado",
                    StatusCode = 200,
                    Data = paisDto
                };
                return response;
            }catch(Exception e)
            {
                ResponseDto response = new ResponseDto
                {
                    Success = false,
                    Message = "Error al obtener el pais",
                    StatusCode = 500,
                    Data = e.Message
                };
                return response;
            }
           
        }

   
    }
}
