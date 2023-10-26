using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMapper
{
    public class ProveedorCategoriaMap : IEntityTypeConfiguration<ProveedorCategoria>
    {
        public void Configure(EntityTypeBuilder<ProveedorCategoria> builder)
        {
           builder.HasKey(x => x.Id)
                .HasName("PK_ProveedorCategoriaId");

            builder.ToTable("ProveedorCategoria");  

            builder.Property(x => x.Id)
               .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.ProveedorId)    
                .HasColumnName("ProveedorId")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.CategoriaId)
                .HasColumnName("CategoriaId")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.EstadoId)
                .HasColumnName("EstadoId")
                .HasColumnType("int")
                .IsRequired();

            //navegacion con Proveedor
            builder.HasOne(x => x.Proveedor)
                .WithMany(x => x.ProveedorCategorias)
                .HasForeignKey(x => x.ProveedorId)
                .HasConstraintName("FK_ProveedorCategoria_Proveedor")
                .OnDelete(DeleteBehavior.Restrict);

            //navegacion con Categoria
            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.ProveedorCategorias)
                .HasForeignKey(x => x.CategoriaId)
                .HasConstraintName("FK_ProveedorCategoria_Categoria")
                .OnDelete(DeleteBehavior.Restrict);

            //navegacion con Estado
            builder.HasOne(x => x.Estado)
                .WithMany(x => x.ProveedorCategorias)
                .HasForeignKey(x => x.EstadoId)
                .HasConstraintName("FK_ProveedorCategoria_Estado")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
