﻿using DomainLayer.Models;
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
    public class DocumentoMap : IEntityTypeConfiguration<Documento>
    { 
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.HasKey(x => x.Id)
                  .HasName("PK_DocumentoId");

            builder.ToTable("Documento");

            builder.Property(x => x.Id)
               .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar(100)")
                .IsRequired(false);
            builder.Property(x => x.FechaEmicion)
                .HasColumnName("FechaEmicion")
                .HasColumnType("datetime")
                .IsRequired(false);
            builder.Property(x => x.FechaVencimiento)
                .HasColumnName("FechaVencimiento")
                .HasColumnType("datetime")
                .IsRequired(false);
            builder.Property(x => x.EstadoId)
                .HasColumnName("EstadoId")
                .HasColumnType("int")
                .IsRequired(false);
            builder.Property(x => x.ProveedorId)
                .HasColumnName("ProveedorId")
                .HasColumnType("int")
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

            //navegacion con Estado
            builder.HasOne(x => x.Estados)
                .WithMany(x => x.Documentos)
                .HasForeignKey(x => x.EstadoId)
                .HasConstraintName("FK_Documento_Estado")
                .OnDelete(DeleteBehavior.Restrict);

            //navegacion con Proveedor
            builder.HasOne(x => x.Proveedores)
                .WithMany(x => x.Documentos)
                .HasForeignKey(x => x.ProveedorId)
                .HasConstraintName("FK_Documento_Proveedor")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
