using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMapper
{
    public class RolUsuarioMap : IEntityTypeConfiguration<RolUsuario>
    {
        public void Configure(EntityTypeBuilder<RolUsuario> builder)
        {
           builder.HasKey(x=>x.Id)
                .HasName("PK_RolUsuarioId");

            builder.ToTable("RolUsuario");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.RolId)
                .HasColumnName("RolId")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.UsuarioId)
                .HasColumnName("UsuarioId")
                .HasColumnType("int")
                .IsRequired();

            //navegacion con Rol
            builder.HasOne(x => x.Rol)
                .WithMany(x => x.RolUsuarios)
                .HasForeignKey(x => x.RolId)
                .HasConstraintName("FK_RolUsuario_Rol")
                .OnDelete(DeleteBehavior.Restrict);

            //navegacion con Usuario
            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.RolUsuarios)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_RolUsuario_Usuario")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
