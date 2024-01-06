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
                .HasColumnName("Nombre")
                .HasColumnType("varchar(50)")
                .IsRequired(false);
            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(50)")
                .IsRequired(false);
            builder.Property(x => x.isAdmin)
                .HasColumnName("isAdmin")
                .HasColumnType("bit")
                .IsRequired(false);

            builder.Property(x => x.EstadoId)
                .HasColumnName("EstadoId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.UserIdAzure)
                .HasColumnName("UserIdAzure")
                .HasColumnType("varchar(150)")
                .IsRequired(false);

            //BaseEntity
            builder.Property(x => x.CreadoPor)
                .HasColumnName("CreadoPor")
                .HasColumnType("int")
                .IsRequired(false);
            builder.Property(x => x.FechaCreacion)
                .HasColumnName("FechaCreacion")
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
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.EstadoId)
                .HasConstraintName("FK_Usuario_Estado")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
