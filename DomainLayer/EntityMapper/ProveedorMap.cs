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
    public class ProveedorMap : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
           builder.HasKey(x => x.Id)
                .HasName("PK_ProveedorId");

            builder.ToTable("Proveedor");

            builder.Property(x => x.Id)
               .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.Identificacion)
                .HasColumnName("Identificacion")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.IdentificacionTipo)
                .HasColumnName("IdentificacionTipo")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.ContactoPrimario)
                .HasColumnName("ContactoPrimario")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.ContactoSecundario)
                .HasColumnName("ContactoSecundario")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.Direccion)
                .HasColumnName("Direccion")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.Telefono)
                .HasColumnName("Telefono")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.PaginaWeb)
                .HasColumnName("PaginaWeb")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.Movil)
                .HasColumnName("Movil")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.Idioma)
                .HasColumnName("Idioma")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.Observacion)    
                .HasColumnName("Observacion")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
            builder.Property(x => x.CodigoProveedorSap)
                .HasColumnName("CodigoProveedorSap")
                .HasColumnType("varchar(200)")
                .IsRequired(false);

            builder.Property(x => x.CiudadId)
                .HasColumnName("CiudadId")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.UsuarioId)
                .HasColumnName("UsuarioId")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.EstadoId)
                .HasColumnName("EstadoId")
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

            ////navegacion con Ciudad
            ///
            builder.HasOne(x => x.Ciudad)
                .WithMany(x => x.Proveedores)
                .HasForeignKey(x => x.CiudadId)
                .HasConstraintName("FK_Proveedor_Ciudad")
                .OnDelete(DeleteBehavior.Restrict);
            //navegacion con estado
            builder.HasOne(x => x.Estado)
                .WithMany(x => x.Proveedores)
                .HasForeignKey(x => x.EstadoId)
                .HasConstraintName("FK_Proveedor_Estado")
                .OnDelete(DeleteBehavior.Restrict);
            //navegacion con usuario

        }
    }
}
