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
    public class ReferenciaMap : IEntityTypeConfiguration<Referencia>
    {
        public void Configure(EntityTypeBuilder<Referencia> builder)
        {
            builder.HasKey(x => x.Id)
                  .HasName("PK_ReferenciaId");

            builder.ToTable("Referencia");

            builder.Property(x => x.Id)
               .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.Contacto)
                .HasColumnName("Contacto")
                .HasColumnType("varchar(100)")
                .IsRequired(false);
            builder.Property(x => x.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime")
                .IsRequired(false);
            builder.Property(x => x.Telefono)
                .HasColumnName("Telefono")
                .HasColumnType("varchar(20)")
                .IsRequired(false);
            builder.Property(x => x.EstadoId)
                .HasColumnName("EstadoId")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.ProveedorId)
                .HasColumnName("ProveedorId")
                .HasColumnType("int")
                .IsRequired();

            //BaseEntity

            builder.Property(x => x.CreadoPor)
                .HasColumnName("CreadoPor")
                .HasColumnType("int")
                .IsRequired(false);
            builder.Property(x => x.FechaCreacion)
                .HasColumnName("fechaCreacion")
                .HasColumnType("datetime")
                .IsRequired(false);
            builder.Property(x => x.ModificadoPor)
                .HasColumnName("ModificadoPor")
                .HasColumnType("int")
                .IsRequired(false);
            builder.Property(x => x.FechaModificacion)
                .HasColumnName("FechaModificacion")
                .HasColumnType("datetime")
                .IsRequired(false);

            //navegacion con Estado
            builder.HasOne(x => x.Estado)
                .WithMany(x => x.Referencias)
                .HasForeignKey(x => x.EstadoId)
                .HasConstraintName("FK_Referencia_Estado")
                .OnDelete(DeleteBehavior.Restrict);

            //navegacion con Proveedor
            builder.HasOne(x => x.Proveedor)
                .WithMany(x => x.Referencias)
                .HasForeignKey(x => x.ProveedorId)
                .HasConstraintName("FK_Referencia_Proveedor")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
