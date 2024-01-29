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
    public class EstadoService : IEstadoService
    {
        private IRepository<Estado> _repository;


        public EstadoService(IRepository<Estado> repository)
        {
            _repository = repository;
        }

        public IEnumerable<EstadoDto>? GetAllEstados()
        {
            try
            {
                IEnumerable<Estado> estados = _repository.GetAll();
                List<EstadoDto> estadoDto = new List<EstadoDto>();
                foreach (var estado in estados)
                {
                    estadoDto.Add(new EstadoDto
                    {
                        Id = estado.Id,
                        Nombre = estado.Nombre, 
                    });
                }
                return estadoDto;
            }catch(Exception)
            {
               return null;
            }
           
        }

        public ResponseDto stateDocument()
        {
            try
            {
                IEnumerable<Estado> estados = _repository.GetAll();
                List<EstadoDto> estadoDto = new List<EstadoDto>();
                foreach (var estado in estados)
                {
                    if(estado.Nombre == "Revisión" || estado.Nombre =="Aprobado" || estado.Nombre == "Rechazado" || estado.Nombre==" Expirado")
                    {
                        estadoDto.Add(new EstadoDto
                        {
                            Id=estado.Id,
                            Nombre=estado.Nombre,
                        });
                    }
                }
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Estados Encontrados",
                    StatusCode = 200,
                    Data = estadoDto
                };
                return responseDto;
            }catch(Exception ex)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Documento no encontrado",
                    StatusCode = 500,
                    Data = ex.Message
                };
                return responseDto;
            }
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
