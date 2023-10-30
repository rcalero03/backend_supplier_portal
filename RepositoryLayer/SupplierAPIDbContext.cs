using DomainLayer.EntityMapper;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class SupplierAPIDbContext : DbContext
    { 
        public SupplierAPIDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new TipoDocumentoMap());
            modelBuilder.ApplyConfiguration(new CatalogoDocumentoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new CiudadMap());
            modelBuilder.ApplyConfiguration(new ConfiguracionNotificacionMap());
            modelBuilder.ApplyConfiguration(new DocumentoMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new ProveedorMap());
            modelBuilder.ApplyConfiguration(new ProveedorCategoriaMap());
            modelBuilder.ApplyConfiguration(new ReferenciaMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new RolUsuarioMap());
            modelBuilder.ApplyConfiguration(new SubtipoCompraMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }

        //Dbset todas las tablas
        public DbSet<CatalogoDocumento> CatalogoDocumento { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<ConfiguracionNotificacion> ConfiguracionNotificacion { get; set; }
        public DbSet<Documento> Documento { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<ProveedorCategoria> ProveedorCategoria { get; set; }
        public DbSet<Referencia> Referencias { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolUsuario> RolUsuario { get; set; }
        public DbSet<SubtipoCompra> SubtipoCompra { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}


