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
    public class CatalogoDocumentoMap : IEntityTypeConfiguration<CatalogoDocumento>
    {
       public void Configure(EntityTypeBuilder<CatalogoDocumento> builder)
        {
            builder.HasKey(x => x.Id)
                  .HasName("PK_IdCatalogoDocumento");

            builder.ToTable("CatalogoDocumento");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar(50)")
                .IsRequired(false);  
            builder.Property(x => x.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Requerido)
                .HasColumnName("requerido")
                .HasColumnType("int")
                .IsRequired(false);
            builder.Property(x => x.EstadoId)
                .HasColumnName("EstadoId")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.TipoDocumentoId)
                .HasColumnName("TipoDocumentoId")
                .HasColumnType("int")
                .IsRequired();
            
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

            //navegacion con Estado
            builder.HasOne(x => x.Estados)
                .WithMany(x => x.CatalogoDocumentos)
                .HasForeignKey(x => x.EstadoId)
                .HasConstraintName("FK_CatalogoDocumento_Estado")
                .OnDelete(DeleteBehavior.Restrict);

            //navegacion con TipoDocumento
            builder.HasOne(x => x.TipoDocumentos)
                .WithMany(x => x.CatalogoDocumentos)
                .HasForeignKey(x => x.TipoDocumentoId)
                .HasConstraintName("FK_CatalogoDocumento_TipoDocumento")
                .OnDelete(DeleteBehavior.Restrict);

            //baseEntity isRequire(false)
            builder.Property(x => x.CreadoPor).IsRequired(false);
            builder.Property(x => x.FechaCreacion).IsRequired(false);
            builder.Property(x => x.ModificadoPor).IsRequired(false);
            builder.Property(x => x.FechaModificacion).IsRequired(false);
        }
    }
}
