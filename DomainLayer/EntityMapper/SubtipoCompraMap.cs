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
    public class SubtipoCompraMap : IEntityTypeConfiguration<SubtipoCompra>
    {

        public void Configure(EntityTypeBuilder<SubtipoCompra> builder)
        {
            builder.HasKey(x => x.Id)
                  .HasName("PK_SubtipoCompraId");

            builder.ToTable("SubtipoCompra");

            builder.Property(x => x.Id)
               .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar(100)")
                .IsRequired(false);
            builder.Property(x => x.TipoCompraId)
                .HasColumnName("TipoCompraId")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.ProveedorId)
                .HasColumnName("ProveedorId")
                .HasColumnType("int")
                .IsRequired();

            //navegacion con TipoCompra
            builder.HasOne(x => x.TipoCompra)
                .WithMany(x => x.SubtipoCompras)
                .HasForeignKey(x => x.TipoCompraId)
                .HasConstraintName("FK_SubtipoCompra_TipoCompra")
                .OnDelete(DeleteBehavior.Restrict);

            //navegacion con Proveedor
            builder.HasOne(x => x.Proveedor)
                .WithMany(x => x.SubtipoCompras)
                .HasForeignKey(x => x.ProveedorId)
                .HasConstraintName("FK_SubtipoCompra_Proveedor")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
