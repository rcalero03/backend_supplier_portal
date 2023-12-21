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
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
           builder.HasKey(x => x.Id)
            .HasName("PK_CategoriaId");

            builder.ToTable("Categoria");

           builder.Property(x=> x.Id)
               .HasColumnName("Id")
               .HasColumnType("int")
               .IsRequired();
            builder.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Descripcion)
                .HasColumnName("descripcion")
                .HasColumnType("varchar(200)");
            builder.Property(x => x.GrupoCompra)
                .HasColumnName("grupoCompra")
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Comprador)
                .HasColumnName("comprador")
                .HasColumnType("varchar(200)");
            builder.Property(x => x.EstadoId)
                .HasColumnName("estadoId")
                .HasColumnType("int");

            //BaseEntity
                builder.Property(x => x.CreadoPor)
                .HasColumnName("CreadoPor")
                .HasColumnType("int");
            builder.Property(x => x.FechaCreacion)
                .HasColumnName("fechaCreacion")
                .HasColumnType("datetime");
            builder.Property(x => x.ModificadoPor)
                .HasColumnName("ModificadoPor")
                .HasColumnType("int");
            builder.Property(x => x.FechaModificacion)
                .HasColumnName("FechaModificacion")
                .HasColumnType("datetime");

            //todas las propiedades nullas
            builder.Property(x => x.Nombre).IsRequired(false);
            builder.Property(x => x.Descripcion).IsRequired(false);
            builder.Property(x => x.GrupoCompra).IsRequired(false);
            builder.Property(x => x.Comprador).IsRequired(false);
            //baseEntity isRequire(false)
            builder.Property(x => x.CreadoPor).IsRequired(false);
            builder.Property(x => x.FechaCreacion).IsRequired(false);
            builder.Property(x => x.ModificadoPor).IsRequired(false);
            builder.Property(x => x.FechaModificacion).IsRequired(false);

            //navegacion con Estado
            builder.HasOne(x => x.Estado)
                .WithMany(x => x.Categorias)
                .HasForeignKey(x => x.EstadoId)
                .HasConstraintName("FK_Categoria_Estado")
                .OnDelete(DeleteBehavior.Restrict);
                

        }
    }
}
