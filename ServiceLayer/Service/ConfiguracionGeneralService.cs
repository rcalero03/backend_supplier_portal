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
    internal class ConfiguracionGeneralService
    {
        private IRepository<ConfiguracionGeneral> _repository;

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
                    generalDtos.codigo = item.Codigo;
                    generalDtos.valor1 = item.Valor1 == null ? string.Empty : item.Valor1;
                    generalDtos.valor2 = item.Valor2 == null ? string.Empty : item.Valor2;
                    generalDtos.valor3 = item.Valor3 == null ? string.Empty : item.Valor3;
                    generalDtos.valor4 = item.Valor4 == null ? string.Empty : item.Valor4;
                    generalDtos.valor5 = item.Valor5 == null ? string.Empty : item.Valor5;
                }

            }
            return generalDtos;

        }

    }
}
