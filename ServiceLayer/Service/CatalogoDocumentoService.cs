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
    public  class CatalogoDocumentoService : ICatalogoDocumentoService
    {
        private readonly IRepository<CatalogoDocumento> _repository;

        public CatalogoDocumentoService(IRepository<CatalogoDocumento> repository)
        {
            _repository = repository;
        }

         public IEnumerable<CatalogoDocumento> GetAllCatalogoDocumento()
        {
            return _repository.GetAll();
        }

        public List<CatalogoDocumentoDto> GetCatalogoDocumentoById(int id)
        {
            List<CatalogoDocumentoDto> catalogoDocumentoDtos = new List<CatalogoDocumentoDto>();
            CatalogoDocumento catalogoDocumento = _repository.GetById(id);
            catalogoDocumentoDtos.Add(new CatalogoDocumentoDto
            {
                Id = catalogoDocumento.Id,
                Nombre = catalogoDocumento.Nombre == null ? string.Empty : catalogoDocumento.Nombre,
                Descripcion = catalogoDocumento.Descripcion == null ? string.Empty : catalogoDocumento.Descripcion,
                Requerido = catalogoDocumento.Requerido = catalogoDocumento.Requerido,
                FechaCreacion = catalogoDocumento.FechaCreacion == null ? DateTime.Now : catalogoDocumento.FechaCreacion,
                FechaModificacion = catalogoDocumento.FechaModificacion == null ? DateTime.Now : catalogoDocumento.FechaModificacion,
                CreadoPor = catalogoDocumento.CreadoPor == null ? 0 : catalogoDocumento.CreadoPor,
                ModificadoPor = catalogoDocumento.ModificadoPor == null ? 0 : catalogoDocumento.ModificadoPor,
                EstadoId = catalogoDocumento.EstadoId,
                TipoDocumentoId = catalogoDocumento.TipoDocumentoId

            });
 
            return catalogoDocumentoDtos;

        }

        public void InsertCatalogoDocumento(CatalogoDocumento catalogoDocumento)
        {
            _repository.Insert(catalogoDocumento);
            _repository.SaveChange();
        }

        public void RemoveCatalogoDocumento(CatalogoDocumento catalogoDocumento)
        {
            var catalogoDocumentoToRemove = _repository.GetById(catalogoDocumento.Id);
            _repository.Remove(catalogoDocumentoToRemove);
            _repository.SaveChange();
        }

        public void UpdateCatalogoDocumento(CatalogoDocumento catalogoDocumento)
        {
            _repository.Update(catalogoDocumento);
            _repository.SaveChange();
        }



    }
}
