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
    public class ConfiguracionGeneralMap : IEntityTypeConfiguration<ConfiguracionGeneral>
    {
        public void Configure(EntityTypeBuilder<ConfiguracionGeneral> builder)
        {
            builder.HasKey(x => x.Id)
                  .HasName("PK_ConfiguracionGeneralId");

            builder.ToTable("ConfiguracionGeneral");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Codigo)
                .HasColumnName("Codigo")
                .HasColumnType("varchar(100)")
                .IsRequired(false);

            builder.Property(x => x.Valor1)
                .HasColumnName("Valor1")
                .HasColumnType("varchar(200)")
                .IsRequired(false);

            builder.Property(x => x.Valor2)
                .HasColumnName("Valor2")
                .HasColumnType("varchar(200)")
                .IsRequired(false);

            builder.Property(x => x.Valor3)
                .HasColumnName("Valor3")
                .HasColumnType("varchar(200)")
                .IsRequired(false);

            builder.Property(x => x.Valor4)
                .HasColumnName("Valor4")
                .HasColumnType("varchar(200)")
                .IsRequired(false);

            builder.Property(x => x.Valor5)
                .HasColumnName("Valor5")
                .HasColumnType("varchar(200)")
                .IsRequired(false);


            builder.Property(x => x.EstadoId)
                .HasColumnName("EstadoId")
                .HasColumnType("int")
                .IsRequired();

            //baseEntity
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
                .WithMany(x => x.ConfiguracionGeneral)
                .HasForeignKey(x => x.EstadoId)
                .HasConstraintName("FK_ConfiguracionGeneral_Estado")
                .OnDelete(DeleteBehavior.Restrict);

            //baseEntity isRequire(false)
            builder.Property(x => x.CreadoPor).IsRequired(false);
            builder.Property(x => x.FechaCreacion).IsRequired(false);
            builder.Property(x => x.ModificadoPor).IsRequired(false);
            builder.Property(x => x.FechaModificacion).IsRequired(false);
        }
    }
}
