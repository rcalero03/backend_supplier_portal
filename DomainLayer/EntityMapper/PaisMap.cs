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
    public class PaisMap : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.HasKey(x => x.Id)
                  .HasName("PK_PaisId");

            builder.ToTable("Pais");
            
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar(100)")
                .IsRequired(false);

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

        }
    }
}
