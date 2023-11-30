using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RepositoryLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SupplierAPIDbContext _dbContext;
        private DbSet<T> entities;

        public Repository(SupplierAPIDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable().OrderByDescending(x => x.Id);
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }            
            Update(entity);
        }

        public T GetById(int id)
        {
            var encuentra = entities.SingleOrDefault(x => x.Id == id);

            if (encuentra == null)
            {
                throw new Exception("El elemento no se encontró en la colección.");
           
            }

            return encuentra;
        }


        public void Insert(T entity)
        {
          if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);

        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
           
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);

        }

    }

}
