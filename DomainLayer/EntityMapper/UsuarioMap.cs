using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMapper
{
     public class UsuarioMap :IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id)
                  .HasName("PK_UsiarioId");

            builder.ToTable("Usuario");
            
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.Nombre)
                .HasColumnName("usuario")
                .HasColumnType("varchar(50)")
                .IsRequired(false);
            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)")
                .IsRequired(false);

            builder.Property(x => x.EstadoId)
                .HasColumnName("EstadoId")
                .HasColumnType("int")
                .IsRequired();


        //navegacion con Estado
        builder.HasOne(x => x.Estado)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.EstadoId)
                .HasConstraintName("FK_Usuario_Estado")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
