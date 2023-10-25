using DomainLayer.EntityMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public  class SupplierAPIDbContext : DbContext
    {
        public SupplierAPIDbContext() { }
        public SupplierAPIDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new TipoDocumentoMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DomainLayer.Models.Estado> Estado { get; set; }
        public DbSet<DomainLayer.Models.TipoDocumento> TipoDocumento { get; set; }

    }
}
