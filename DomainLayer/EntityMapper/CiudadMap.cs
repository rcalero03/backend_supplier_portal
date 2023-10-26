using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMapper
{
    public class CiudadMap : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.HasKey(x => x.Id)
                  .HasName("PK_CiudadId");

            builder.ToTable("Ciudad");

            builder.Property(x => x.Id)
               .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(builder => builder.nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar(100)")
                .IsRequired(false);
            builder.Property(builder => builder.PaisId)
                .HasColumnName("PaisId")
                .HasColumnType("int")
                .IsRequired();
      
            //navegacion con Pais
            builder.HasOne(x => x.Pais)
                .WithMany(x => x.Ciudades)
                .HasForeignKey(x => x.PaisId)
                .HasConstraintName("FK_Ciudad_Pais")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
