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
    public class ConfiguracionGeneralService : IConfiguracionGeneralService
    {
        private IRepository<ConfiguracionGeneral> _repository;


        public ConfiguracionGeneralService(IRepository<ConfiguracionGeneral> repository)
        {
            _repository = repository;
        }

        public IEnumerable<ConfiguracionGeneral> GetAllConfiguracionGenerales()
        {
            return _repository.GetAll();
        }

        public ConfiguracionGeneralDto GetByCode(string code)
        {
            ConfiguracionGeneralDto generalDtos = new ConfiguracionGeneralDto();

            foreach (var item in GetAllConfiguracionGenerales())
            {
                if (item.Codigo == code)
                {
                    generalDtos.Codigo = item.Codigo;
                    generalDtos.Valor1 = item.Valor1 == null ? string.Empty : item.Valor1;
                    generalDtos.Valor2 = item.Valor2 == null ? string.Empty : item.Valor2;
                    generalDtos.Valor3 = item.Valor3 == null ? string.Empty : item.Valor3;
                    generalDtos.Valor4 = item.Valor4 == null ? string.Empty : item.Valor4;
                    generalDtos.Valor5 = item.Valor5 == null ? string.Empty : item.Valor5;
                }

            }
            return generalDtos;

        }
    }
}
