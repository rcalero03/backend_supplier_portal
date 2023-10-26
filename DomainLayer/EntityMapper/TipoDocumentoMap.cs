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
    public class TipoDocumentoMap : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder)
        {
            builder.HasKey(x => x.Id)
                  .HasName("PK_TipoDocumentoId");

            builder.ToTable("Tipo_Documento");

            builder.Property(x => x.Id)
               .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();
            
            builder.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar(100)")
                .IsRequired(false);
            builder.Property(x => x.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.EstadoId)
                .HasColumnName("EstadoId")
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

            ////navegacion con Estado
            builder.HasOne(x => x.Estado)
                .WithMany(x => x.TipoDocumentos)
                .HasForeignKey(x => x.EstadoId)
                .HasConstraintName("FK_TipoDocumento_Estado")
                .OnDelete(DeleteBehavior.Restrict);

            //baseEntity isRequire(false)
            builder.Property(x => x.CreadoPor).IsRequired(false);
            builder.Property(x => x.FechaCreacion).IsRequired(false);
            builder.Property(x => x.ModificadoPor).IsRequired(false);
            builder.Property(x => x.FechaModificacion).IsRequired(false);

        }
    }
}
