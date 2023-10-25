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
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private IRepository<TipoDocumento> _repository;
        EstadoService estadoService;

        public TipoDocumentoService(IRepository<TipoDocumento>  repository)
        {
            _repository = repository;
        }
        public IEnumerable<TipoDocumento> GetAllTipoDocumentos()
        {
            var tipoDocumentos = _repository.GetAll();

            return tipoDocumentos;
        }
        public TipoDocumento GetTipoDocumentoById(int id)
        {
           return _repository.GetById(id);
        }

        public void InsertTipoDocumento(TipoDocumento tipoDocumento)
        {
            _repository.Insert(tipoDocumento);
            _repository.SaveChange();

        }

        public void RemoveTipoDocumento(TipoDocumento tipoDocumento)
        {
           var estado  = _repository.GetById(tipoDocumento.Id);
            _repository.Remove(estado);
            _repository.SaveChange();
        }
        public void UpdateTipoDocumento(TipoDocumento tipoDocumento)
        {
            var estado = _repository.GetById(tipoDocumento.Id); 
            _repository.Update(estado);
            _repository.SaveChange();

        }

    }
}
